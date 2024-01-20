using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileSecondVersion.Infrastructure;


namespace PortfolioSecondVersion
{
    public class HomeController : Controller
    {
        private readonly ProfileSecondVersionContext _context;

        public HomeController(ProfileSecondVersionContext context)
        {
            _context = context;
        }
        // GET: HomeController
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewHome ViewHome = new ViewHome();

            Profile Profile = await _context.Profiles
                .Include(p => p.Photo)
                .Include(p => p.Post)
                .Include(p => p.ProfileCommunication)
                .Include(p => p.ProfileLanguage)
                .ThenInclude(pl => pl.Language)
                .FirstOrDefaultAsync();
            ViewHome.Posts = PostService.ConvertToView(Profile.Post.ToList());
            ViewHome.Id = Profile.Id.ToString();
            ViewHome.ImageBase64 =  Convert.ToBase64String(Profile.Photo.FirstOrDefault().ImageData);
            ViewHome.FullName = String.Format("{0} {1}", Profile.Name, Profile.Surname);
            ViewHome.Communications = Profile.ProfileCommunication.Select(c => c.Number).ToList();
            ViewHome.Languages = Profile.ProfileLanguage.Select(l => l.Language.Name).ToList();
            HttpContext.Session.SetJson("ViewHome", ViewHome);
            return View(ViewHome);
        }

        public ActionResult AddPost() 
        {

            return View();
        }
        [HttpPost]
        public async Task<ViewResult> EditePost(ViewPost post)
        {
            var postToUpdate = await _context.Posts
                    .FirstOrDefaultAsync(p => p.ProfileId.ToString() == post.ProfileId);

            if (postToUpdate != null)
            {
                postToUpdate.Title = post.Title;
                postToUpdate.StartDate = post.StartDate;
                postToUpdate.DueDate = post.DueDate;
                postToUpdate.CompanyNames = post.CompanyNames;
                postToUpdate.Description = post.Description;
                try
                {
                    _context.Posts.Update(postToUpdate);
                    await _context.SaveChangesAsync();
                    
                }
                catch (DbUpdateException ex) 
                {
                    return View(ex);
                }
            }
            return View();
        }
    }
}
