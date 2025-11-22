using Fiap.Api.FinancaFacil.Data.Contexts;
using Fiap.Api.FinancaFacil.Models;

namespace Fiap.Api.FinancaFacil.Data.Repository
{
    public class ExampleRepository : IExampleRepository
    {

        private readonly DatabaseContext _context;

        public ExampleRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<ExampleModel> GetAll() => _context.Examples.ToList();

        public ExampleModel? GetById(int id) => _context.Examples.Find(id);

        public void Add(ExampleModel example)
        {
            _context.Examples.Add(example);
            _context.SaveChanges();
        }

        public void Update(ExampleModel example)
        {
            _context.Examples.Update(example);
            _context.SaveChanges();
        }

        public void Delete(ExampleModel example)
        {
            _context.Examples.Remove(example);
            _context.SaveChanges();
        }
    }
}
