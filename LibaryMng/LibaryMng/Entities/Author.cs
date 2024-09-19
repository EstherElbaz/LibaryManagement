namespace LibaryMng.Entities
{
    public class Author
    {
        public string id { get; set; }
        public string name { get; set; }
        public (int StartYear, int EndYear) publicationRange { get; set; }


    }
}
