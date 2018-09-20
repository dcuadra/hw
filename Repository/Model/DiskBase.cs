namespace Repository.Model
{
    public class DiskBase : EntityId
    {
        /// <summary>
        /// Title of the disk
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The year of publication
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// The bookshelves where is that disk
        /// </summary>
        public int BookshelvesId { get; set; }
    }
}
