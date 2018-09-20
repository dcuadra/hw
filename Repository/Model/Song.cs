using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Model
{
    [Table("Song")]
    public class Song:SongBase
    { 
        public virtual Disk Disk { get; set; }
    }
}
