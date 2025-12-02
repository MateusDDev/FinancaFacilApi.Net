namespace Fiap.Api.FinancaFacil.Models;

public class CursoModel
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public int CargaHoraria { get; set; }
    public string Nivel { get; set; } = string.Empty;
    public DateTime DtCriacao { get; set; }
}