using Microsoft.EntityFrameworkCore;
using Therma_Plus_DotNet.DTOs;
using Therma_Plus_DotNet.Models;

namespace Therma_Plus_DotNet.Data;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly DataContext _context;

    public UsuarioRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<UsuarioDTO>> GetAllAsync()
    {
        return await _context.Usuarios
            .Include(u => u.Regiao)
            .Select(u => new UsuarioDTO
            {
                Nome = u.Nome,
                Idade = u.Idade,
                Doenca = u.Doenca,
                Estado = u.Regiao.Estado.ToString(),
                Cidade = u.Regiao.Cidade
            })
            .ToListAsync();
    }

    public async Task<Usuario> GetByIdAsync(int id)
    {
        return await _context.Usuarios.FindAsync(id);
    }

    public async Task<Usuario> GetInfoDisplay(int id)
    {
        return await _context.Usuarios.FindAsync(id);
    }
    
    public async Task AddUsuarioAsync(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateUsuarioAsync(Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUsuarioAsync(int id)
    {
        Console.WriteLine("entrei no repository");
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario != null)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }
}