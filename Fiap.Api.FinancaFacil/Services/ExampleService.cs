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

        public async Task<IList<ExampleModel>> GetExamples(int lastReference, int size)
        {
            return await _repository.GetAll(lastReference, size);
        }

        public async Task<ExampleModel?> GetExampleById(int id) => await _repository.GetById(id);

        public Task CreateExample(ExampleModel example) => _repository.Add(example);

        public Task UpdateExample(ExampleModel example) => _repository.Update(example);

        public async Task DeleteExample(int id)
        {
            var example = await _repository.GetById(id);
            
            if (example is not null)
                await _repository.Delete(example);
        }
    }
}
