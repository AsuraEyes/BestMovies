﻿using MovieServer.Models;

namespace MovieServer.MiddlePoints
{
    public interface IPostMiddlePoint
    {
        Task CreatePostAsync(Post post);
        Task<List<Post>> GetAllPostsAsync();
    }
}