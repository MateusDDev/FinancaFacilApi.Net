using Fiap.Api.FinancaFacil.Data.Repository;
using Fiap.Api.FinancaFacil.Models;

namespace Fiap.Api.FinancaFacil.Services
{
    public class ExampleService : IExampleService
    {

        private readonly IExampleRepository _repository;

        public ExampleService(IExampleRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ExampleModel> GetExamples() => _repository.GetAll();

        public ExampleModel? GetExampleById(int id) => _repository.GetById(id);

        public void CreateExample(ExampleModel example) => _repository.Add(example);

        public void UpdateExample(ExampleModel example) => _repository.Update(example);

        public void DeleteExample(int id)
        {
            var example = _repository.GetById(id);
            if (example != null)
            {
                _repository.Delete(example);
            }
        }

    }
}
