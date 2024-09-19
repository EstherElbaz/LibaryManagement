namespace LibaryMng.Entities
{
    public class Borrower
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public List<string> BorrowHistory { get; set; } = new List<string>(); 
        public Borrower(string id, string fullName, string phoneNumber, string email)
        {
            Id= id;
            FullName= fullName;
            PhoneNumber= phoneNumber;
            Email= email;
            IsActive = true;
            BorrowHistory= new List<string>();
        }
        public void BorrowBook(string bookId)
        {
            BorrowHistory.Add(bookId);
            return;
        }
    }
}