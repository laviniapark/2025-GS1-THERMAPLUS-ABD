using Therma_Plus_DotNet.DTOs;
using Therma_Plus_DotNet.Models;

namespace Therma_Plus_DotNet.Data;

public interface IUsuarioRepository
{
    Task<IEnumerable<UsuarioDTO>> GetAllAsync();
    Task<Usuario> GetByIdAsync(int id);
    Task<Usuario> GetInfoDisplay(int id);
    Task AddUsuarioAsync(Usuario usuario);
    Task UpdateUsuarioAsync(Usuario usuario);
    Task DeleteUsuarioAsync(int id);
}