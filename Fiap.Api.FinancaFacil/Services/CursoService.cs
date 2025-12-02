using Fiap.Api.FinancaFacil.Data.Repository;
using Fiap.Api.FinancaFacil.Models;

namespace Fiap.Api.FinancaFacil.Services;

public class CursoService : ICursoService
{
    private readonly ICursoRepository _repository;

    public CursoService(ICursoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IList<CursoModel>> GetCursos(int lastReference, int size)
    {
        return await _repository.GetAll(lastReference, size);
    }

    public async Task<CursoModel?> GetCursoById(int id) => await _repository.GetById(id);

    public Task CreateCurso(CursoModel curso) => _repository.Add(curso);

    public Task UpdateCurso(CursoModel curso) => _repository.Update(curso);

    public async Task DeleteCurso(int id)
    {
        var curso = await _repository.GetById(id);
            
        if (curso is not null)
            await _repository.Delete(curso);
    }
}