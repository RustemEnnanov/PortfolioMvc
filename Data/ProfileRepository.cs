using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
using PortfolioSecondVersion;


namespace PortfolioSecondVersion
{
    public class ProfileRepository
    {
        private readonly ProfileSecondVersionContext context;
        public ProfileRepository(ProfileSecondVersionContext _context)
        {
            context = _context;  
        }
        public async Task<List<Profile>> GetAll() 
        {
            return  await context.Profiles.ToListAsync();
        }
        public void Create(Profile newProfile)
        { 
            if (newProfile.Id != null)
            {
                context.Add(newProfile);
                context.SaveChanges();
            }
        }
       /* public Profile DeleteProfile(int ProfileId)
        {
            Product dbEntry = _context.Products.FirstOrDefault(p => p.ProductID == ProfileId);
            if (dbEntry != null)
            {
                _databaseContex.Products.Remove(dbEntry);
                _databaseContex.SaveChanges();
            }
            return dbEntry;
        }*/
    }
}
