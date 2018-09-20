using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Model
{
    [Table("Disk")]
    public class Disk : DiskBase
    {
        /// <summary>
        /// Songs in the disk
        /// </summary>
        public virtual List<Song> Songs{ get => songs ?? (songs = new List<Song>()); set => songs = value; }
        List<Song> songs;

        public virtual Bookshelves Bookshelves { get; set; }

    }
}
