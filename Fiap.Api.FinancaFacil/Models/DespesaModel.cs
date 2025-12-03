namespace Fiap.Api.FinancaFacil.Models;

public class DespesaModel
{
    public int IdDespesa { get; set; }
    public int IdUsuario { get; set; }
    public string Categoria { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public DateTime Data { get; set; }
}