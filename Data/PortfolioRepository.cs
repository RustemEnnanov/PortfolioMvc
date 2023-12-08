using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
using PortfolioSecondVersion.Models;

namespace PortfolioSecondVersion.Data
{
    public class PortfolioRepository
    {
        private readonly PortfolioSecondVersionContext context;
        public PortfolioRepository(PortfolioSecondVersionContext _context)
        {
            context = _context;  
        }
        public async Task<List<Portfolio>> GetAll() 
        {
            return  await context.Portfolios.ToListAsync();
        }
        public void Create(Portfolio newPortfolio)
        { 
            if (newPortfolio.Id != null)
            {
                context.Add(newPortfolio);
                context.SaveChanges();
            }
        }
       /* public Portfolio DeletePortfolio(int portfolioId)
        {
            Product dbEntry = _context.Products.FirstOrDefault(p => p.ProductID == portfolioId);
            if (dbEntry != null)
            {
                _databaseContex.Products.Remove(dbEntry);
                _databaseContex.SaveChanges();
            }
            return dbEntry;
        }*/
    }
}
