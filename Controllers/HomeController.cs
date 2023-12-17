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
                .FirstOrDefaultAsync();
            ViewHome.Id = Profile.Id.ToString();
            ViewHome.ImageBase64 =  Convert.ToBase64String(Profile.Photo.FirstOrDefault().ImageData);
            ViewHome.FullName = String.Format("{0} {1}", Profile.Name, Profile.Surname);
            HttpContext.Session.SetJson("ViewHome", ViewHome);
            return View(ViewHome);
        }

        public ActionResult AddPost() 
        {

            return View();
        }
    }
}
