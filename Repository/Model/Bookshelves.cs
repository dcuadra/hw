using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Model
{
    [Table("Bookshelves")]
    /// <summary>
    /// Are the differents bookshelves of a library
    /// </summary>
    public class Bookshelves : BookshelvesBase
    {
        /// <summary>
        /// Are the books entities
        /// </summary>
        public virtual List<Book> Books { get => books ?? (books = new List<Book>()); set => books = value; }
        List<Book> books;
        /// <summary>
        /// Disks in the bookshelves
        /// </summary>
        public virtual List<Disk> Disks { get => disks ?? (disks = new List<Disk>()); set => disks = value; }
        List<Disk> disks;
    }
}
