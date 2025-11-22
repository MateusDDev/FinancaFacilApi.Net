using Fiap.Api.FinancaFacil.Models;

namespace Fiap.Api.FinancaFacil.Data.Repository
{
    public interface IExampleRepository
    {
        IEnumerable<ExampleModel> GetAll();
        ExampleModel? GetById(int id);
        void Add(ExampleModel example);
        void Update(ExampleModel example);
        void Delete(ExampleModel example);

    }
}
