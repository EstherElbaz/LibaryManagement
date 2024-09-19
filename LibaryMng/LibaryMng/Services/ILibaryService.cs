using LibaryMng.Entities;
using System.Net;

namespace LibaryMng.Services
{
    public interface ILibaryService
    {
        public Task LoadBooks();
        public Task LoadBorrowers();
        public Task<bool> borrow(string borrowerId, string bookId);
        public Task<bool> returnBook(string bookId);
        public List<Book> getAllBooks();
        public Task<Book> addBook(Book book);
        public Book getBookByName(string title);
        public List<Book> getBooksByAuthor(string authorId);
        public Task archiveBook(string bookId);
        public List<Book> getBooksByCategory(string category);
        public List<Book> getAvailableBooks();
        public List<Book> getOverdueBooks(int days);
        public Borrower getBorrowerByName(string name);
        public Task<Borrower> addBorrower(Borrower newBorrower);



        //public Task<Book>  getBookById(string Id);














    }
}
