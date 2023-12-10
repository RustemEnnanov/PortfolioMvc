using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PortfolioSecondVersion.Data;
using PortfolioSecondVersion.Models;

namespace PortfolioSecondVersion.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly ILogger<PortfolioController> _logger;
        private readonly PortfolioSecondVersionContext _context;

        public PortfolioController(PortfolioSecondVersionContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create(Portfolio newPortfolio)
        {
            var languages = new List<Language> {
                new Language { Id = Guid.NewGuid(), Name = "A" },
                new Language { Id = Guid.NewGuid(), Name = "B" },
                new Language { Id = Guid.NewGuid(), Name = "C" },
                new Language { Id = Guid.NewGuid(), Name = "D" },
                new Language { Id = Guid.NewGuid(), Name = "E" },
                new Language { Id = Guid.NewGuid(), Name = "BF" }
            };//new SelectList(await _context.Lenguages.ToListAsync<Language>());

            ViewPortfolio portfolios = new ViewPortfolio();
            portfolios.Languages = new List<SelectListItem> {
            new SelectListItem { Text = "One", Value = "1" },
            new SelectListItem { Text = "Two", Value = "2" },
            new SelectListItem { Text = "Three", Value = "3" },
            new SelectListItem { Text = "Four", Value = "4" },
            new SelectListItem { Text = "Five", Value = "5" }
        };

            // ViewBag.Languages = await _context.Lenguages.ToListAsync<Language>();
            MultiSelectList selectListTwo = new MultiSelectList(portfolios.Languages, "Value", "Text");
           // ViewBag.Languages = selectListTwo;

            return View(portfolios);
        }
        [HttpGet]
        public void SetPortfolio(ViewPortfolio newPortfolio)
        {
            var a = newPortfolio;
            //_context.Portfolios.Add(newPortfolio.Portfolio);
            //_context.SaveChanges();
        }

    }
}