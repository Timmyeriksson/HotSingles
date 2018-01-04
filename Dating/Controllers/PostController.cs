using Datalayer;
using Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Dating.Controllers
{
    public class PostController : ApiController
    {
        private Datacontext db = new Datacontext();

        public IQueryable<Posts> GetPosts()
        {
            return db.Post;
        }

        public List<Posts> OldPosts(int id)
        {
            List<Posts> oldPost = db.Post.ToList();
            List<Posts> RelevantPosts = new List<Posts>();

            foreach (Posts post in oldPost)
            {
                if (post.ReciverID == id)
                {
                    RelevantPosts.Add(post);
                }
            }
            return RelevantPosts;
        }
        [HttpPost, ActionName("insertPost")]
        public void insertPost([FromBody] Posts newPost)
        {
            if (newPost.TextContent != "")
            {
                db.Post.Add(newPost);
                db.SaveChanges();
            }
        }
    }
}

