namespace Fiap.Api.FinancaFacil.ViewModel;

public class CursoViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public int CargaHoraria { get; set; }
    public string Nivel { get; set; } = string.Empty;
    public DateTime DtCriacao { get; set; }
}

public class InputCursoViewModel
{
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public int CargaHoraria { get; set; }
    public string Nivel { get; set; } = string.Empty;
    public DateTime DtCriacao { get; set; }
}

public class ListCursosViewModel
{
    public IEnumerable<CursoViewModel>? Cursos { get; set; }
    public int? NextCursor { get; set; }

    public int PageSize { get; set; }

    private bool HasMore => NextCursor.HasValue;

    public string NextUrl => HasMore ? $"api/curso?cursor={NextCursor}&size={PageSize}" : "";
}