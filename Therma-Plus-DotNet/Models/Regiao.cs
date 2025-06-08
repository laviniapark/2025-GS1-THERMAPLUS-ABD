using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Therma_Plus_DotNet.Models;

[Table("TBL_REGIOES")]
public class Regiao
{
    [Key]
    [Column("id_regiao")]
    public int RegiaoId { get; set; }

    [Column("estado")]
    public Estado Estado { get; set; }

    [Column("cidade")]
    public string Cidade { get; set; }
    
    public ICollection<Usuario> Usuarios { get; set; }
}

public enum Estado
{
    AC,
    AL,
    AP,
    AM,
    BA,
    CE,
    DF,
    ES,
    GO,
    MA,
    MT,
    MS,
    MG,
    PA,
    PB,
    PR,
    PE,
    PI,
    RJ,
    RN,
    RS,
    RO,
    RR,
    SC,
    SP,
    SE,
    TO
}