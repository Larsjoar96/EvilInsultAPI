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
            if (!ValidLanguage(obj.Language))
            {
                throw new BadHttpRequestException("Invalid language please use en, es or de");
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

        public async Task<ICollection<Insult>> GetAllAsync()
        {
            return await _context.Insults.ToListAsync();
        }

        public async Task<Insult> GetByIdAsync(int id)
        {
            if (!await InsultExists(id)) 
            {
                throw new EntityNotFoundExeption("No Insult with id: " + id);
            }
            return await _context.Insults.Where(i => i.Id == id).FirstAsync();
        }

        public async Task UpdateAsync(Insult obj)
        {
            if (!await InsultExists(obj.Id))
            {
                throw new EntityNotFoundExeption("No Insult with id: " + obj.Id);
            }
            if (!ValidLanguage(obj.Language))
            {
                throw new BadHttpRequestException("Invalid language please use en, es or de");
            }
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<ICollection<Insult>> GetAllInsultsInLanguageAsync(string language)
        {
            if (!ValidLanguage(language))
            {
                throw new BadHttpRequestException("Invalid language please use en, es or de");
            }
            return await _context.Insults.Where(i => i.Language == language).ToListAsync();
        }
        private bool ValidLanguage(string language) 
        {
            if (language != "en" && language != "es" && language != "de")
            {
                return false;
            }
            return true;
        }
        private async Task<bool> InsultExists(int id)
        {
            return await _context.Insults.AnyAsync(u => (u.Id) == id);
        }
        
    }
}
