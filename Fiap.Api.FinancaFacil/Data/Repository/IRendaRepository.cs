using Fiap.Api.FinancaFacil.Models;

namespace Fiap.Api.FinancaFacil.Data.Repository;

public interface IRendaRepository
{
    Task<IList<RendaModel>> GetAll(int lastReference, int size);
    Task<RendaModel?> GetById(int id);
    Task Add(RendaModel example);
    Task Update(RendaModel example);
    Task Delete(RendaModel example);
}