namespace LibaryMng.Entities
{
    //public class Libary
    //{
    //    public List<Book> Books { get; set; }
    //    public List<Borrower> Borrowers { get; set; } = new List<Borrower>();

    //    public Libary() 
    //    { 
    //        Books = new List<Book>();
    //        Borrowers = new List<Borrower>();
    //    }

    //    public void addBorrower(Borrower newBorrower)
    //    {
    //        Borrowers.Add(newBorrower);    
    //    }
    //    public void AddBook(Book newBook) { 
    //        Books.Add(newBook);
    //    }
    //    public List<Book> SearchBookByCategory(string categoryName)
    //    { 
    //        List<Book> booksForCategory = new List<Book>();
    //        foreach(Book book in Books)
    //        {
    //            if (book.Category == categoryName)
    //                booksForCategory.Add(book);   
    //        }
    //        return booksForCategory;
    //    }

    //    public List<Book> SearchForOverdueBooks(int days)
    //    {
    //        List<Book> overdueBooks= new List<Book>();
    //        DateTime currentDate = DateTime.Now;

    //        foreach(var book in Books)
    //        {
    //            TimeSpan difference = currentDate-book.LastBorrowDate;

    //            if (difference.Days > days)
    //            {
    //                overdueBooks.Add(book);
    //            }
    //        }
    //        return overdueBooks;
    //    }

    //    public List<Book> SearchAllAvailableBooks()
    //    {
    //        List<Book> availableBooks = new List<Book>();
    //        foreach(var book in Books)
    //        {
    //            if (book.IsBorrowed==false)
    //                availableBooks.Add(book);   
    //        }
    //        return availableBooks;
    //    }
    //}
}
