namespace Fiap.Api.FinancaFacil.ViewModel;

public class ExampleViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string Email { get; set; }
}

public class InputExampleViewModel
{
    public string Name { get; set; }
    public string Email { get; set; }
}

public class ListExamplesViewModel
{
    public IEnumerable<ExampleViewModel> Examples { get; set; }
    public int? NextCursor { get; set; }

    public int PageSize { get; set; }

    private bool HasMore => NextCursor.HasValue;

    public string NextUrl => HasMore ? $"/Example?after={NextCursor}&size={PageSize}" : "";
}