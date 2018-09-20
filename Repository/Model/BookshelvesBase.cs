namespace Repository.Model
{
    public class BookshelvesBase : EntityId
    {
        /// <summary>
        /// Is the nombre of the lane or way in the library
        /// </summary>
        public int Lane { get; set; }
        /// <summary>
        /// Is the height where is the bookshelves
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// Is the column where is the bookshelves
        /// </summary>
        public int Rack { get; set; }
    }
}
