using MongoDB.Bson.Serialization.Attributes;

namespace MovieServer.Models
{
    public class Post
    {
        [BsonElement("title")]
        public string Title { get; set; }
        [BsonElement("content")]

        public string Content { get; set; }
        [BsonElement("posted_date")]

        public DateTime PostedDate { get; set; }
        [BsonElement("posted_by")]

        public string PostedBy { get; set; }
    }
}
