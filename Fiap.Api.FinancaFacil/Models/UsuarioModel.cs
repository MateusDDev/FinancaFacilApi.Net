using System.Text.Json.Serialization;

namespace Fiap.Api.FinancaFacil.Models;

public class UsuarioModel
{
    public int IdUsuario { get; set; }

    [JsonPropertyName("cpf")]
    public string Cpf { get; set; } = string.Empty;

    [JsonPropertyName("nmUsuario")]
    public string NmUsuario { get; set; } = string.Empty;

    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    [JsonPropertyName("celular")]
    public string Celular { get; set; } = string.Empty;

    [JsonPropertyName("dtNascimento")]
    public DateTime DtNascimento { get; set; }

    [JsonPropertyName("senha")]
    public string Senha { get; set; } = string.Empty;
    
    public virtual List<RendaModel> Rendas { get; set; }
}