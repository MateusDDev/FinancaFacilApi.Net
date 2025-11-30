using Fiap.Api.FinancaFacil.Models;
using Fiap.Api.FinancaFacil.ViewModel;

namespace Fiap.Api.FinancaFacil.Services;

public interface IRendaService
{
    Task<IList<RendaModel>> GetRendas(int lastReference, int size);
    Task<RendaModel?> GetRendaById(int id);
    Task CreateRenda(RendaModel example);
    Task UpdateRenda(RendaModel example);
    Task DeleteRenda(int id);
}