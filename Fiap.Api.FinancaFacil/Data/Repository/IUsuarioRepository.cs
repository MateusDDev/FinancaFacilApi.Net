using Fiap.Api.FinancaFacil.Models;

namespace Fiap.Api.FinancaFacil.Data.Repository;

public interface IUsuarioRepository
{
    Task<IList<UsuarioModel>> GetAll(int lastReference, int size);
    Task<UsuarioModel?> GetById(int id);
    Task Add(UsuarioModel example);
    Task Update(UsuarioModel example);
    Task Delete(UsuarioModel example);
    Task<UsuarioModel?> GetByEmail(string email);
}