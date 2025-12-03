namespace Fiap.Api.FinancaFacil.ViewModel;

public class DespesaViewModel
{
    public int IdDespesa { get; set; }
    public int IdUsuario { get; set; }
    public string Categoria { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public DateTime Data { get; set; }
}

public class InputDespesaViewModel
{
    public int IdUsuario { get; set; }
    public string Categoria { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public DateTime Data { get; set; }
}

public class ListDespesasViewModel
{
    public IList<DespesaViewModel> Despesas { get; set; } = new List<DespesaViewModel>();
    public int PageSize { get; set; }
    public int? NextCursor { get; set; }
}