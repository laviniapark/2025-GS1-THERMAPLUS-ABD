using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Therma_Plus_DotNet.Models;

[Table("TBL_USUARIOS")]
public class Usuario
{
    [Key]
    [Column("id_usuario")]
    public int UsuarioId { get; set; }

    [Column("id_regiao")]
    public int RegiaoId { get; set; }
    public  Regiao Regiao { get; set; }

    [Column("nome")]
    public required string Nome { get; set; }

    [Column("idade")]
    public required int Idade { get; set; }

    [Column("doenca_cronica")]
    public string? Doenca { get; set; }
    

}

