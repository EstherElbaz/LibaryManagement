using LibaryMng.Entities;

namespace LibaryMng.Repositories
{
    public interface ILibaryRepository
    {
        public Task<List<Book>> LoadBooks();
        public Task SaveBooksData(List<Book> books);
        public Task<List<Borrower>> LoadBorrowers();
        public Task SaveBorrowersData(List<Borrower> borrowers);
    }
}