namespace Fiap.Api.FinancaFacil.ViewModel;

public class UsuarioViewModel
{
    public int IdUsuario { get; set; }
    public string Cpf { get; set; } = string.Empty;
    public string NmUsuario { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Celular { get; set; } = string.Empty;
    public DateTime DtNascimento { get; set; }
    public string Senha { get; set; } = string.Empty;
}

public class InputUsuarioViewModel
{
    public string Cpf { get; set; } = string.Empty;
    public string NmUsuario { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Celular { get; set; } = string.Empty;
    public DateTime DtNascimento { get; set; }
    public string Senha { get; set; } = string.Empty;
}

public class ListUsuariosViewModel
{
    public IEnumerable<UsuarioViewModel>? Usuarios { get; set; }
    public int? NextCursor { get; set; }

    public int PageSize { get; set; }

    private bool HasMore => NextCursor.HasValue;

    public string NextUrl => HasMore ? $"/usuarios?cursor={NextCursor}&size={PageSize}" : "";
}