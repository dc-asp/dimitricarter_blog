using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dimitricarter_blog.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Slug { get; set; }
        public string MediaUrl { get; set; }

        public bool Published { get; set; }

        public DateTimeOffset created { get; set; }
        public DateTimeOffset Updated { get; set; }

        //Virtual Nav Section
        public virtual ICollection<Comment> Comments { get; set; }

        public BlogPost()
        {
            Comments = new HashSet<Comment>();
        }

    }
}