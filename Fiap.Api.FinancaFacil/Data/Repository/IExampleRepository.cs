using Fiap.Api.FinancaFacil.Models;

namespace Fiap.Api.FinancaFacil.Data.Repository
{
    public interface IExampleRepository
    {
        Task<IList<ExampleModel>> GetAll(int lastReference, int size);
        Task<ExampleModel?> GetById(int id);
        Task Add(ExampleModel example);
        Task Update(ExampleModel example);
        Task Delete(ExampleModel example);

    }
}
