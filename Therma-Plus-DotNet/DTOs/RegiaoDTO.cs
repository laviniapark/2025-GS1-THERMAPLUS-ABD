using Therma_Plus_DotNet.Models;

namespace Therma_Plus_DotNet.DTOs;

public class RegiaoDTO
{
    public int RegiaoId { get; set; }
    
    public Estado Estado { get; set; }
    
    public string Cidade { get; set; }
}