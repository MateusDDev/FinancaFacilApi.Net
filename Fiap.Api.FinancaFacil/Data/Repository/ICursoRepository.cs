using Fiap.Api.FinancaFacil.Models;

namespace Fiap.Api.FinancaFacil.Data.Repository;

public interface ICursoRepository
{
    Task<IList<CursoModel>> GetAll(int lastReference, int size);
    Task<CursoModel?> GetById(int id);
    Task Add(CursoModel example);
    Task Update(CursoModel example);
    Task Delete(CursoModel example);
}