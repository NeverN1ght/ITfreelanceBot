using ITfreelanceBot.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ITfreelanceBot.Repositories
{
    public class DeveloperRepository
    {
        private readonly DbContext _context;

        public DeveloperRepository(DbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Developer developer)
        {
            _context.Set<Developer>().Add(developer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Developer developer)
        {
            _context.Set<Developer>().Remove(developer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Developer developer)
        {
            _context.Entry<Developer>(developer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Developer>> GetAllAsync()
        {
            return await _context.Set<Developer>().ToListAsync();
        }

        public async Task<Developer> GetByIdAsync(int telegramId)
        {
            return await _context.Set<Developer>().SingleOrDefaultAsync(d => d.TelegramId == telegramId);
        }

        public async Task<bool> IsExistAsync(int telegramId)
        {
            return await _context.Set<Developer>().AnyAsync(d => d.TelegramId == telegramId);
        }
    }
}