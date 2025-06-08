using AutoMapper;
using Therma_Plus_DotNet.DTOs;
using Therma_Plus_DotNet.Models;

namespace Therma_Plus_DotNet.Mapeamento;

public class RegiaoProfile : Profile
{
    public RegiaoProfile()
    {
        CreateMap<Regiao, RegiaoDTO>().ReverseMap();
    }
}