using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MovieServer.Models
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("content")]
        public string Content { get; set; }

        [BsonElement("postedDate")]
        public DateTime PostedDate { get; set; }

        [BsonElement("postedBy")]
        public string PostedBy { get; set; }

        [BsonElement("picture")]
        public byte[] Picture { get; set; }

        [BsonElement("username")]
        public string Username { get; set; }

        [BsonElement("numberOfLikes")]
        public int NumberOfLikes { get; set; }
        [BsonElement("numberOfDislikes")]

        public int NumberOfDislikes { get; set; }


        [BsonElement("likedByUsers")]
        public List<string> LikedByUsers { get; set; }

        [BsonElement("disLikedByUsers")]
        public List<string> DisLikedByUsers { get; set; }


    }
}
