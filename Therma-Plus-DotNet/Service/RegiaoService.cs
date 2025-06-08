using AutoMapper;
using Therma_Plus_DotNet.Data;
using Therma_Plus_DotNet.DTOs;
using Therma_Plus_DotNet.Models;

namespace Therma_Plus_DotNet.Service;

public class RegiaoService
{
    private readonly IRegiaoRepository _regiaoRepository;
    private readonly IMapper _mapper;

    public RegiaoService(IRegiaoRepository regiaoRepository, IMapper mapper)
    {
        _regiaoRepository = regiaoRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RegiaoDTO>> GetAllRegioesAsync()
    {
        var regioes = await _regiaoRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<RegiaoDTO>>(regioes);
    }

    public async Task<RegiaoDTO> GetRegiaoByIdAsync(int id)
    {
        var regiao = await _regiaoRepository.GetByIdAsync(id);
        return _mapper.Map<RegiaoDTO>(regiao);
    }

    public async Task<int> AddRegiaoAsync(RegiaoDTO regiaoDto)
    {
        var regiao = _mapper.Map<Regiao>(regiaoDto);
        return await _regiaoRepository.AddRegiaoAsync(regiao);
    }

    public async Task UpdateRegiaoAsync(RegiaoDTO regiaoDto)
    {
        var regiao = _mapper.Map<Regiao>(regiaoDto);
        await _regiaoRepository.UpdateRegiaoAsync(regiao);
    }

    public async Task DeleteRegiaoAsync(int id)
    {
        await _regiaoRepository.DeleteRegiaoAsync(id);
    }
}