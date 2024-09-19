using LibaryMng.Entities;
using LibaryMng.Repositories;
using System.Net;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibaryMng.Services
{
    public class LibaryService : ILibaryService
    {
        private ILibaryRepository _libaryRepository;
        //כדי לשפר ביצועים הוספתי משתנה שישמור את כל הנתונים בקאש ,
        //וכך ביצועי השליפות יהיו מהירים יותר 
        //כמובן שכל שמירה של נתונים חדשים תהיה גם בdatabase.
        //אתחול כרשימה ריקה, הפניה הראשונה לספריה בקונטרולר תגרום לטעינת הספרים
       
        private List<Book> _books = new List<Book>();
        private List<Borrower> _borrowers = new List<Borrower>();

        public LibaryService(ILibaryRepository LibaryRepository)
        {
            _libaryRepository = LibaryRepository;
        }
        public async Task LoadBooks()
        {
            _books= await _libaryRepository.LoadBooks();
            foreach (var v in _books) Console.WriteLine(v.Title);
        }

        public async Task LoadBorrowers()
        {
            _borrowers = await _libaryRepository.LoadBorrowers();
            foreach (var v in _borrowers) Console.WriteLine(v.FullName);
        }

        public Borrower getBorrowerByName(string name)
        {
            return _borrowers.Find(b => b.FullName == name);
        }

        public async Task<bool> borrow(string borrowerId, string bookId)
        {
            foreach (var b in _borrowers)
            {
                if (b.Id == borrowerId)
                {
                    b.BorrowHistory.Add(bookId);
                    await _libaryRepository.SaveBorrowersData(_borrowers);
                    foreach (var book in _books)
                        if (book.Id == bookId)
                        {
                            book.IsBorrowed = true;
                            book.LastBorrowDate = DateTime.Now;
                            await _libaryRepository.SaveBooksData(_books);
                            return true;
                        }
                }
            }
            return false;
        }
        public async Task<bool> returnBook(string bookId)
        {
            foreach (var book in _books)
                if (book.Id == bookId)
                {
                    book.IsBorrowed = false;
                    await _libaryRepository.SaveBooksData(_books);
                    return true;
                }
            return false; 
        }

        public async Task<Borrower> addBorrower(Borrower newBorrower)
        {
            newBorrower.Id = generateBorrowerId(newBorrower);
            _borrowers.Add(newBorrower);
            await _libaryRepository.SaveBorrowersData(_borrowers);
            return newBorrower;
        }
        private string generateBorrowerId(Borrower borrower)
        {
            return borrower.FullName + DateTime.Now.ToString();
        }

        public List<Book> getAllBooks()
        {
            return _books;   
        }
        public async Task<Book> addBook(Book book)
        {
            book.Id = generateBookId(book);
            //if book not exist...
            _books.Add(book);
            await _libaryRepository.SaveBooksData(_books);
            return book;
        }
        private string generateBookId(Book book)
        {
            return book.AuthorId + DateTime.Now.ToString(); 
        }
        public Book getBookByName(string title)
        {
                foreach (Book book in _books)
                    if (book.Title == title)
                        return book;
            return null; 
        }
        public List<Book> getBooksByAuthor(string authorId)
        {
            List<Book> booksForAuthor = new List<Book>();
            foreach (Book book in _books)
            {
                if (book.AuthorId == authorId)
                    booksForAuthor.Add(book);
            }
            return booksForAuthor;
        }
        public async Task archiveBook(string bookId)
        {
            foreach (Book book in _books)
                if (book.Id == bookId)
                    book.IsActive = false;
            await _libaryRepository.SaveBooksData(_books);
            return;
        }
        public List<Book> getBooksByCategory(string category)
        {
            List<Book> booksForCategory = new List<Book>();
            foreach (Book book in _books)
                if (book.Category == category)
                    booksForCategory.Add(book);
            return booksForCategory;
        }
        public List<Book> getAvailableBooks()
        {
            List<Book> availableBooks = new List<Book>();
            foreach (Book book in _books)
                if (book.IsBorrowed == false&&book.IsActive==true)
                    availableBooks.Add(book);
            return availableBooks;
        }
        public List<Book> getOverdueBooks(int days)
        {
            List<Book> overdueBooks = new List<Book>();
            DateTime currentDate = DateTime.Now;

            foreach (var book in _books)
            {
                TimeSpan difference = currentDate - book.LastBorrowDate;
                if (difference.Days > days)
                {
                    overdueBooks.Add(book);
                }
            }
            return overdueBooks;
        }

        //public Task<Book> getBookById(string Id)
        //{
        //    
        //}
    }
}