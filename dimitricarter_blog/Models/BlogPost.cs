using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace dimitricarter_blog.Models
{
    public class BlogPost
    {
        public BlogPost()
        {
            this.Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Slug { get; set; }
        [AllowHtml]
        public string Body { get; set; }
        

        public bool Published { get; set; }

        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }

        //Virtual Nav Section
        public virtual ICollection<Comment> Comments { get; set; }
        public string MediaURL { get; internal set; }
    }
    
namespace dimitricarter_blog.Controllers
    {
        public class LandingPageVM
        {
            public BlogPost LeftPost { get; set; }
            public BlogPost TopRightPost { get; set; }
            public BlogPost BottomLeftPost { get; set; }
            public BlogPost BottomRight { get; set; }
        }
    }
}