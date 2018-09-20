using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Model
{
    [Table("Book")]
    /// <summary>
    /// Entity of a book
    /// </summary>
    public class Book: BookBase
    {
        public virtual Bookshelves Bookshelves { get; set; }
    }
}
