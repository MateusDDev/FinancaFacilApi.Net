using Fiap.Api.FinancaFacil.Models;

namespace Fiap.Api.FinancaFacil.Data.Repository;

public interface IDespesaRepository
{
    Task<IList<DespesaModel>> GetAll(int lastReference, int size);
    Task<DespesaModel?> GetById(int id);
    Task Add(DespesaModel model);
    Task Update(DespesaModel model);
    Task Delete(DespesaModel model);
}