using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioSecondVersion.Data;
using PortfolioSecondVersion.Models;

namespace PortfolioSecondVersion.Controllers
{
    public class HomeController : Controller
    {
        private readonly PortfolioSecondVersionContext _context;

        public HomeController(PortfolioSecondVersionContext context)
        {
            _context = context;
        }
        // GET: HomeController
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewIndex viewIndex = new ViewIndex();
            
            Portfolio portfolio = await _context.Portfolios
                .Include(p => p.Photo)
                .FirstOrDefaultAsync();
            viewIndex.ImageBase64 =  Convert.ToBase64String(portfolio.Photo.FirstOrDefault().ImageData);
            viewIndex.FullName = String.Format("{0} {1}", portfolio.Name, portfolio.Surname);

            return View(viewIndex);
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
