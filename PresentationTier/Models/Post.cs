using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PresentationTier.Models
{
    public class Post
    {

        public string Id { get; set; }

        public string Content { get; set; }

        public DateTime PostedDate { get; set; }

        public string PostedBy { get; set; }


        public string Username { get; set; }
    }
}
