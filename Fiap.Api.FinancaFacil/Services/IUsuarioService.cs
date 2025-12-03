using Fiap.Api.FinancaFacil.Models;
using Fiap.Api.FinancaFacil.ViewModel;

namespace Fiap.Api.FinancaFacil.Services;

public interface IUsuarioService
{
    Task<IList<UsuarioModel>> GetUsuarios(int lastReference, int size);
    Task<UsuarioModel?> GetUsuarioById(int id);
    Task CreateUsuario(UsuarioModel example);
    Task UpdateUsuario(UsuarioModel example);
    Task DeleteUsuario(int id);
    Task<UsuarioModel?> GetUsuarioByEmail(string email);

}