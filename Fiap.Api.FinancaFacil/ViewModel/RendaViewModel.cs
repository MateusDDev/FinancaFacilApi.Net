namespace Fiap.Api.FinancaFacil.ViewModel;

public class RendaViewModel
{
    public int IdRenda { get; set; }
    public int IdUsuario { get; set; }
    public int CdRenda { get; set; }
    public string TpRenda { get; set; } = string.Empty;
    public decimal VlRenda { get; set; }
}
public class InputRendaViewModel
{
    public int IdRenda { get; set; }
    public int IdUsuario { get; set; }
    public int CdRenda { get; set; }
    public string TpRenda { get; set; } = string.Empty;
    public decimal VlRenda { get; set; }
}

public class ListRendasViewModel
{
    public IEnumerable<RendaViewModel> Renda { get; set; }
    public int? NextCursor { get; set; }

    public int PageSize { get; set; }

    private bool HasMore => NextCursor.HasValue;

    public string NextUrl => HasMore ? $"/usuarios?cursor={NextCursor}&size={PageSize}" : "";
}