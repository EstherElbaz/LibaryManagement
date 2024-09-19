using LibaryMng.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;


namespace LibaryMng.Repositories
{
    public class LibaryRepository:ILibaryRepository
    {
        private readonly string _booksFilePath = "Data/Books.json";
        private readonly string _borrowersFilePath = "Data/Borrowers.json";
        public async Task<List<Book>> LoadBooks()
        {
            string text = await File.ReadAllTextAsync(_booksFilePath);
            List<Book> books = JsonSerializer.Deserialize<List<Book>>(text);
            Console.WriteLine(books);   
            return books;
        }
        public async Task SaveBooksData(List<Book> books)
        {
            var json = JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_booksFilePath, json);
        }
        public async Task<List<Borrower>> LoadBorrowers()
        {
            var text = await File.ReadAllTextAsync(_borrowersFilePath);
            return JsonSerializer.Deserialize<List<Borrower>>(text);
        }
        public async Task SaveBorrowersData(List<Borrower> borrowers)
        {
            var json = JsonSerializer.Serialize(borrowers, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_borrowersFilePath, json);
        }
    }
}
