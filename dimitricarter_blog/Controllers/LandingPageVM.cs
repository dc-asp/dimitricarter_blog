using dimitricarter_blog.Models;

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