using EvilInsultAPI.Models;
using EvilInsultAPI.Models.Domain;
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
            await _context.Insults.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
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
    }
}
