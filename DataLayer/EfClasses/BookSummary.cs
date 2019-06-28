namespace DataLayer.EfClasses
{
    public class BookSummary
    {
        public int BookSummaryId { get; set; }
        public string Title { get; set; }
        public string AuthorString { get; set; }
        public BookDetail Details { get; set; }
    }

    public class BookDetail
    {
        public int BookDetailId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}