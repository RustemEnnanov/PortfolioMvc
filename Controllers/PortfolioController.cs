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

            // ViewBag.Languages = await _context.Lenguages.ToListAsync<Language>();
            MultiSelectList selectList = new MultiSelectList(languages,"Id", "Name");
            ViewBag.Languages = selectList;

            return View();
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