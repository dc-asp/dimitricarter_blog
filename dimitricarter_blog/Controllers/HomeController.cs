using dimitricarter_blog.Views.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Net.Mail;
using dimitricarter_blog.Models;

namespace dimitricarter_blog.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var posts = db.BlogPosts.Where(b => b.Published).OrderByDescending(b => b.Created).Take(4).ToList();

            var myLandingPageVM = new LandingPageVM
            {
                LeftPost = posts.FirstOrDefault(),
                TopRightPost = posts.Skip(1).FirstOrDefault(),
                BottomLeftPost = posts.Skip(2).FirstOrDefault(),
                BottomRight = posts.LastOrDefault()
            };
            return View(myLandingPageVM);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            EmailModel model = new EmailModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //var body = "<p>Email From: <bold>{0}</bold>({1})</p><p>Message:</p><p>{2}</p>";
                    var from = $"{model.FromEmail}<{WebConfigurationManager.AppSettings["emailto"]}>";
                    //model.Body = "This is a message from your portfolio site. The name and the email of the contacting person is above.";
                    var email = new MailMessenger(from, WebConfigurationManager.AppSettings["emailto"])
                    {
                        Subject = model.Subject,
                        Body =  model.Body,
                        IsBodyHtml = true
                    };
                    var sync = new PersonalEmail();
                    await svc.SendAsync(email);

                    return View(new EmailModel());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    await Task.FromResult(0);
                }
            }
            return View(model);
        }
    }
}
