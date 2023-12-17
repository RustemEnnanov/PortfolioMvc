using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfileSecondVersion;
using ProfileSecondVersion.Infrastructure;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PortfolioSecondVersion.Controllers
{
    public class PostController : Controller
    {
        // GET: PostController
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ViewPost newPost)
        {
            var post = newPost;

            var homeData = GetProfile();
            SaveProfile(newPost);
            return View();
        }
        public ViewHome GetProfile()
        {
            ViewHome viewHome = HttpContext.Session.GetJson<ViewHome>("ViewHome") ?? new ViewHome();
            return viewHome;
        }
        public void SaveProfile(ViewPost viewPost)
        {
            HttpContext.Session.SetJson("Post", viewPost);
        }

    }
}
