using Fiap.Api.FinancaFacil.Models;

namespace Fiap.Api.FinancaFacil.Services
{
    public interface IExampleService
    {
        Task<IList<ExampleModel>> GetExamples(int lastReference, int size);
        Task<ExampleModel?> GetExampleById(int id);
        Task CreateExample(ExampleModel example);
        Task UpdateExample(ExampleModel example);
        Task DeleteExample(int id);

    }
}
