using System;

namespace PresentationTier.Models
{
    public class Post
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostedDate { get; set; }
        public User PostedBy { get; set; }
    }

}