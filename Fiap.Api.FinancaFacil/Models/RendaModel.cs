namespace Fiap.Api.FinancaFacil.Models;

public class RendaModel
{
    public int IdRenda { get; set; }
    public int IdUsuario { get; set; }
    public int CdRenda { get; set; }
    public string TpRenda { get; set; } = string.Empty;
    public decimal VlRenda { get; set; }
}