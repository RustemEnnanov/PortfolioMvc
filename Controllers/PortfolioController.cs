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
            var languages = await _context.Languages.ToListAsync<Language>();

            ViewPortfolio viewAddPage = new ViewPortfolio();

            viewAddPage.Languages = languages.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();

            return View(viewAddPage);
        }
        [HttpPost]
        public void SetPortfolio(ViewPortfolio addPortfolioData)
        {
            Guid portfolioId = Guid.NewGuid();
            Portfolio newPortfolio = new Portfolio {
                Id = portfolioId,
                Name = addPortfolioData.Name,
                Surname = addPortfolioData.Surname,
                Description = addPortfolioData.Description
            };

            _context.Portfolios.Add(newPortfolio);
            _context.SaveChanges();

            List<LanguagePortfolio> newLanguagePortfolio = addPortfolioData.SelectedItemIds.Select(l => 
                new LanguagePortfolio
                { 
                    PortfolioId = portfolioId,
                    LanguageId = new Guid(l.ToString())
                }).ToList();
 
            _context.LanguagesPortfolios.AddRange(newLanguagePortfolio);
            _context.SaveChanges();
        }

    }
}