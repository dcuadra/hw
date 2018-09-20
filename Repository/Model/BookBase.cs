namespace Repository.Model
{
    public class BookBase:EntityId
    {
        /// <summary>
        /// Title of the book
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Name of the book author
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// The year of publication
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// Number of pages in the book
        /// </summary>
        public int NumPages { get; set; }
        /// <summary>
        /// The bookshelves where is that book
        /// </summary>
        public int BookshelvesId { get; set; }
    }
}
