using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestao_cartoes_bancarios.Models;

public class DetalhesCartao
{
    [Key]
    public int DetalhesCartaoId { get; set; }
    [Column(TypeName ="nvarchar(100)")]
    public string NomeTitularCartao { get; set; } = "";
    [Column(TypeName = "nvarchar(16)")]
    public string numeroCartao { get; set; } = "";
    [Column(TypeName = "nvarchar(5)")]
    public string DataDeValidade { get; set; } = ""; 
    [Column(TypeName = "nvarchar(3)")]
    public string CodigoDeSeguranca { get; set; } = "";
}
