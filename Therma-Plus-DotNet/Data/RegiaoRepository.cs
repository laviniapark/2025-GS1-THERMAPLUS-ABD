using Microsoft.EntityFrameworkCore;
using Therma_Plus_DotNet.Models;

namespace Therma_Plus_DotNet.Data;

public class RegiaoRepository : IRegiaoRepository
{
    private readonly DataContext _context;

    public RegiaoRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Regiao>> GetAllAsync()
    {
        return await _context.Regioes.ToListAsync();
    }

    public async Task<Regiao> GetByIdAsync(int id)
    {
        return await _context.Regioes.FindAsync(id);
    }
    
    public async Task<int> AddRegiaoAsync(Regiao regiao)
    {
        await _context.Regioes.AddAsync(regiao);
        await _context.SaveChangesAsync();
        return regiao.RegiaoId;
    }

    public async Task UpdateRegiaoAsync(Regiao regiao)
    {
        _context.Regioes.Update(regiao);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRegiaoAsync(int id)
    {
        var regiao = await _context.Regioes.FindAsync(id);
        if (regiao != null)
        {
            _context.Regioes.Remove(regiao);
            await _context.SaveChangesAsync();
        }
    }
}