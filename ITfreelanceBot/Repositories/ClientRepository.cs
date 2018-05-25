using ITfreelanceBot.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ITfreelanceBot.Repositories
{
    public class ClientRepository
    {
        private readonly DbContext _context;

        public ClientRepository(DbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Client client)
        {
            _context.Set<Client>().Add(client);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Client client)
        {
            _context.Set<Client>().Remove(client);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Client client)
        {
            _context.Entry<Client>(client).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Client>> GetAllAsync()
        {
            return await _context.Set<Client>().ToListAsync();
        }

        public async Task<Client> GetByIdAsync(int telegramId)
        {
            return await _context.Set<Client>().SingleOrDefaultAsync(c => c.TelegramId == telegramId);
        }

        public async Task<bool> IsExistAsync(int telegramId)
        {
            return await _context.Set<Client>().AnyAsync(c => c.TelegramId == telegramId);
        }
    }
}