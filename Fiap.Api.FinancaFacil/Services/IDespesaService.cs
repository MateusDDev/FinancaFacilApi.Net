using Fiap.Api.FinancaFacil.Models;

namespace Fiap.Api.FinancaFacil.Services;

public interface IDespesaService
{
    Task<IList<DespesaModel>> GetDespesas(int lastReference, int size);
    Task<DespesaModel?> GetDespesaById(int id);
    Task CreateDespesa(DespesaModel model);
    Task UpdateDespesa(DespesaModel model);
    Task DeleteDespesa(int id);
}