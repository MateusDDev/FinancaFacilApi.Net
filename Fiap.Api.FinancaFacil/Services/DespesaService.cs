using Fiap.Api.FinancaFacil.Data.Repository;
using Fiap.Api.FinancaFacil.Models;

namespace Fiap.Api.FinancaFacil.Services;

public class DespesaService : IDespesaService
{
    private readonly IDespesaRepository _repository;

    public DespesaService(IDespesaRepository repository)
    {
        _repository = repository;
    }

    public Task<IList<DespesaModel>> GetDespesas(int lastReference, int size)
        => _repository.GetAll(lastReference, size);

    public Task<DespesaModel?> GetDespesaById(int id)
        => _repository.GetById(id);

    public Task CreateDespesa(DespesaModel model)
        => _repository.Add(model);

    public Task UpdateDespesa(DespesaModel model)
        => _repository.Update(model);

    public async Task DeleteDespesa(int id)
    {
        var item = await _repository.GetById(id);
        if (item != null)
            await _repository.Delete(item);
    }
}