namespace LibaryMng.Entities
{

    public enum Category
    {
        Children,
        Fiction,
        Science,
        Cookbooks
    }
    public class Book
    {
        public string Id { get; set; }
        public string Title {get; set;}
        public string AuthorId { get; set;}
        public string Category { get; set;}
        public bool IsBorrowed { get; set;}
        public DateTime LastBorrowDate { get; set;}
        public bool IsActive { get; set;}

        public Book(string id, string title, string authorID, string category)
        {
            Id = id;
            Title = title;
            AuthorId = authorID;
            Category = category;
            IsBorrowed = false;
            IsActive = true;
            LastBorrowDate = DateTime.Now;
        }
    }
}
