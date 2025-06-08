using AutoMapper;
using Therma_Plus_DotNet.Data;
using Therma_Plus_DotNet.DTOs;
using Therma_Plus_DotNet.Models;

namespace Therma_Plus_DotNet.Service;

public class UsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IRegiaoRepository _regiaoRepository;
    private readonly IMapper _mapper;

    public UsuarioService(IUsuarioRepository usuarioRepository, IRegiaoRepository regiaoRepository, IMapper mapper)
    {
        _usuarioRepository = usuarioRepository;
        _regiaoRepository = regiaoRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UsuarioDTO>> GetAllUsuariosAsync()
    {
        var usuarios = await _usuarioRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
    }

    public async Task<UsuarioDTO> GetUsuarioByIdAsync(int id)
    {
        var usuario = await _usuarioRepository.GetByIdAsync(id);

        return _mapper.Map<UsuarioDTO>(usuario);
    }

    public async Task<UsuarioDTO> GetInfoUsuarioRegiao(int id)
    {
        var usuario = await _usuarioRepository.GetByIdAsync(id);
        
        if (usuario == null) return null;

        usuario.Regiao = await _regiaoRepository.GetByIdAsync(usuario.RegiaoId);

        var dto = new UsuarioDTO
        {
            UsuarioId = usuario.UsuarioId,
            RegiaoId = usuario.RegiaoId,
            Nome = usuario.Nome,
            Idade = usuario.Idade,
            Doenca = usuario.Doenca,
            Estado = usuario.Regiao.Estado.ToString(),
            Cidade = usuario.Regiao.Cidade
        };
        return dto;
    }

    public async Task AddUsuarioAsync(UsuarioDTO usuarioDto)
    {
        var usuario = _mapper.Map<Usuario>(usuarioDto);
        usuario.Regiao = await _regiaoRepository.GetByIdAsync(usuario.RegiaoId);
        await _usuarioRepository.AddUsuarioAsync(usuario);
    }

    public async Task UpdateUsuarioAsync(UsuarioDTO usuarioDto)
    {
        var usuario = _mapper.Map<Usuario>(usuarioDto);
        await _usuarioRepository.UpdateUsuarioAsync(usuario);
    }

    public async Task DeleteUsuarioAsync(int UsuarioId)
    {
        Console.WriteLine("entrei no service");
        await _usuarioRepository.DeleteUsuarioAsync(UsuarioId);
    }
}