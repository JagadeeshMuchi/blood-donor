namespace ASpNetCore.Models
{
    public class SongModel
    {
        public int Id { get; set; }
        public string AlbumName { get; set; }
        public Actor ActorDetils {get;set;}
        public string Song { get; set; }

    }
    public class Actor
    {
        public int aId { get; set; }
        public string ActorName { get; set; }
        public string movieName { get; set; }

    }
    public class response
    {
        public int count { get; set; }
        public int Id { get; set; }
    }
  
}
