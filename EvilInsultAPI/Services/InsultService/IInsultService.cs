using EvilInsultAPI.Models.Domain;

namespace EvilInsultAPI.Services.InsultService
{
    public interface IInsultService : ICrudService <Insult, int>
    {
        Task<ICollection<Insult>> GetAllInsultsInLanguageAsync(string language);
    }
}
