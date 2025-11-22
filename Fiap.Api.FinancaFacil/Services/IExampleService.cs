using Fiap.Api.FinancaFacil.Models;

namespace Fiap.Api.FinancaFacil.Services
{
    public interface IExampleService
    {
        IEnumerable<ExampleModel> GetExamples();
        ExampleModel? GetExampleById(int id);
        void CreateExample(ExampleModel example);
        void UpdateExample(ExampleModel example);
        void DeleteExample(int id);

    }
}
