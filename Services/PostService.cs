using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PortfolioSecondVersion
{
    public static class PostService
    {
        public static List<ViewPost> ConvertToView(List<Post> posts) 
        {
            List<ViewPost> viewPostList = new List<ViewPost>();
            if (posts.Count > 0) 
            {
                foreach (var post in posts)
                {
                    viewPostList.Add( new ViewPost {
                            Title = post.Title,
                            CompanyNames = post.CompanyNames,
                            StartDate = post.StartDate,
                            DueDate = post.DueDate,
                            Position = post.Position,
                            ProfileId = post.ProfileId.ToString(),
                            Description = post.Description }
                    );
                }
            }     
            return viewPostList;
        }
        //public async void Create(ViewPost newpost) 
        //{
        //    var postOnCreate = new Post
        //    {
        //        Title = newpost.Title,
        //        Position = newpost.Position,
        //        StartDate = newpost.StartDate,
        //        DueDate = newpost.DueDate,
        //        CompanyNames = newpost.CompanyNames,
        //        Description = newpost.Description,
        //        ProfileId = new Guid(newpost.ProfileId)
        //    }; 
        //    _context.Posts.Add(postOnCreate);
        //    await _context.SaveChangesAsync();
        //}
        //public async void Edite(ViewPost post) 
        //{
        //    var postToUpdate = await _context.Posts
        //        .FirstOrDefaultAsync(p => p.ProfileId == new Guid(post.ProfileId));
        //    postToUpdate.Title = post.Title;
        //    postToUpdate.StartDate = post.StartDate;
        //    postToUpdate.DueDate = post.DueDate;
        //    postToUpdate.CompanyNames = post.CompanyNames;
        //    postToUpdate.Description = post.Description;
            
        //    _context.Posts.Update(postToUpdate);
        //    await _context.SaveChangesAsync();

        //}
    }
}
