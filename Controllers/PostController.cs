using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfileSecondVersion;
using ProfileSecondVersion.Infrastructure;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PortfolioSecondVersion.Controllers
{
    public class PostController : Controller
    {
        private readonly ProfileSecondVersionContext _context;

        public PostController(ProfileSecondVersionContext context)
        {
            _context = context;
        }
        // GET: PostController
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async void Create(ViewPost newpost)
        {
            newpost.ProfileId = GetProfile().Id;
            var postOnCreate = new Post
            {
                Title = newpost.Title,
                Position = newpost.Position,
                StartDate = newpost.StartDate,
                DueDate = newpost.DueDate,
                CompanyNames = newpost.CompanyNames,
                Description = newpost.Description,
                ProfileId = new Guid(newpost.ProfileId)
            };
            _context.Posts.Add(postOnCreate);
            await _context.SaveChangesAsync();
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
