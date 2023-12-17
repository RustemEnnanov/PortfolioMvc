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

namespace PortfolioSecondVersion
{
    public class ProfileController : Controller
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly ProfileSecondVersionContext _context;

        public ProfileController(ProfileSecondVersionContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Create(Profile newProfile)
        {
            var languages = await _context.Languages.ToListAsync<Language>();

            ViewProfile viewAddPage = new ViewProfile();

            viewAddPage.Languages = languages.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();

            return View(viewAddPage);
        }
        [HttpPost]
        public void SetProfile(ViewProfile addProfileData)
        {
            Profile newProfile = new Profile {
                Id = Guid.NewGuid(),
                Name = addProfileData.Name,
                Surname = addProfileData.Surname,
                BirthDate = addProfileData.BirthDate,
                Description = addProfileData.Description,
                ProfileCommunication = addProfileData.Communications.Select(com => new ProfileCommunication {
                    Title = "Other",
                    Number = com
                }).ToList(),
                ProfileLanguage = addProfileData.SelectedItemIds.Select(l => new ProfileLanguage
                { 
                    LanguageId = l
                }).ToList()               
            };
            if (addProfileData.Avatar != null && addProfileData.Avatar.Length > 0)
            {
                using (var binaryReader = new BinaryReader(addProfileData.Avatar.OpenReadStream()))
                {
                    newProfile.Photo = new List<Image> {
                                 new Image
                                 {
                                     Title = addProfileData.Avatar.Name,
                                     FileName = addProfileData.Avatar.FileName,
                                     ImageData = binaryReader.ReadBytes((int)addProfileData.Avatar.Length)
                                 }
                             };
                }
            }
            _context.Profiles.Add(newProfile);
            _context.SaveChanges();
        }

    }
}