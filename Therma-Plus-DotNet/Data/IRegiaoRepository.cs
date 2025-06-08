using Therma_Plus_DotNet.Models;

namespace Therma_Plus_DotNet.Data;

public interface IRegiaoRepository
{
    Task<IEnumerable<Regiao>> GetAllAsync();
    Task<Regiao> GetByIdAsync(int id);
    Task<int> AddRegiaoAsync(Regiao regiao);
    Task UpdateRegiaoAsync(Regiao regiao);
    Task DeleteRegiaoAsync(int id);
}