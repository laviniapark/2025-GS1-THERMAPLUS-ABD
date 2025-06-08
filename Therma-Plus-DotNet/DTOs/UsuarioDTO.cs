using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Therma_Plus_DotNet.DTOs;

public class UsuarioDTO
{
    public int UsuarioId { get; set; }

    public int RegiaoId { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    public string Nome { get; set; }

    [Range(1, 120, ErrorMessage = "Idade deve ser entre 1 e 120")]
    public int Idade { get; set; }

    public string? Doenca { get; set; }

    [ValidateNever]
    public string Estado { get; set; }
    
    [ValidateNever]
    public string Cidade { get; set; }
}