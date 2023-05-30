using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MovieServer.Models
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("content")]
        public string Content { get; set; }

        [BsonElement("postedDate")]
        public DateTime PostedDate { get; set; }

        [BsonElement("postedBy")]
        public string PostedBy { get; set; }



        [BsonElement("username")]
        public string Username { get; set; }
    }
}
