namespace Fiap.Api.FinancaFacil.Models;

public class UsuarioModel
{
    public int IdUsuario { get; set; }
    public string Cpf { get; set; } = string.Empty;
    public string NmUsuario { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Celular { get; set; } = string.Empty;
    public DateTime DtNascimento { get; set; }
    public string Senha { get; set; } = string.Empty;
}