using Fiap.Api.FinancaFacil.Models;

namespace Fiap.Api.FinancaFacil.Services;

public interface ICursoService
{
    Task<IList<CursoModel>> GetCursos(int lastReference, int size);
    Task<CursoModel?> GetCursoById(int id);
    Task CreateCurso(CursoModel curso);
    Task UpdateCurso(CursoModel curso);
    Task DeleteCurso(int id);
}