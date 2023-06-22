using EvilInsultAPI.Models;
using EvilInsultAPI.Models.Domain;
using EvilInsultAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace EvilInsultAPI.Services.InsultService
{
    public class InsultService : IInsultService
    {
        private readonly EvilDbContext _context;

        public InsultService(EvilDbContext context) 
        {
            _context = context;
        }
        public async Task AddAsync(Insult obj)
        {
            if (obj.Language != "en" && obj.Language != "es" && obj.Language != "de")
            {
                throw new InvalidLanguageExeption("Invalid language please use en, es or de");
            } 
            await _context.Insults.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            if (!await InsultExists(id))
            {
                throw new EntityNotFoundExeption("No Insult with id: " + id);
            }

            var insult = await _context.Insults.FindAsync(id);
            _context.Insults.Remove(insult);
            await _context.SaveChangesAsync();
        }

        public Task<ICollection<Insult>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Insult> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Insult obj)
        {
            throw new NotImplementedException();
        }
        private async Task<bool> InsultExists(int id)
        {
            return await _context.Insults.AnyAsync(u => (u.Id) == id);
        }
    }
}
