using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            Portfolio newPortfolio = new Portfolio {
                Id = Guid.NewGuid(),
                Name = addPortfolioData.Name,
                Surname = addPortfolioData.Surname,
                Description = addPortfolioData.Description,
                ProfileCommunication = addPortfolioData.Communications.Select(com => new ProfileCommunication {
                    Title = "Other",
                    Number = com
                }).ToList(),
                LanguagePortfolio = addPortfolioData.SelectedItemIds.Select(l => new LanguagePortfolio { 
                    LanguageId = l
                }).ToList()               
            };
            if (addPortfolioData.Avatar != null && addPortfolioData.Avatar.Length > 0)
            {
                using (var binaryReader = new BinaryReader(addPortfolioData.Avatar.OpenReadStream()))
                {
                    newPortfolio.Photo = new List<Image> {
                                 new Image
                                 {
                                     Title = addPortfolioData.Avatar.Name,
                                     FileName = addPortfolioData.Avatar.FileName,
                                     ImageData = binaryReader.ReadBytes((int)addPortfolioData.Avatar.Length)
                                 }
                             };
                }
            }
            _context.Portfolios.Add(newPortfolio);
            _context.SaveChanges();
        }

    }
}