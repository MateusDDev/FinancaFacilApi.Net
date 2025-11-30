using Fiap.Api.FinancaFacil.Data.Repository;
using Fiap.Api.FinancaFacil.Models;

namespace Fiap.Api.FinancaFacil.Services;

public class RendaService : IRendaService
{
    private readonly IRendaRepository _repository;

    public RendaService(IRendaRepository repository)
    {
        _repository = repository;
    }

    public async Task<IList<RendaModel>> GetRendas(int lastReference, int size)
    {
        return await _repository.GetAll(lastReference, size);
    }

    public async Task<RendaModel?> GetRendaById(int id) => await _repository.GetById(id);

    public Task CreateRenda(RendaModel renda) => _repository.Add(renda);

    public Task UpdateRenda(RendaModel renda) => _repository.Update(renda);

    public async Task DeleteRenda(int id)
    {
        var renda = await _repository.GetById(id);
            
        if (renda is not null)
            await _repository.Delete(renda);
    }
}