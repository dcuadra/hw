namespace Repository.Model
{
    public class SongBase : EntityId
    {
        /// <summary>
        /// Name of the song
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Writer of the song
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// Player of the song
        /// </summary>
        public string Artist { get; set; }
        /// <summary>
        /// Duration in seconds
        /// </summary>
        public int Duration { get; set; }
        /// <summary>
        /// Disk in wich is the song
        /// </summary>
        public int DiskId { get; set; }
    }
}
