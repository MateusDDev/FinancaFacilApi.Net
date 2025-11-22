using Fiap.Api.FinancaFacil.Data.Contexts;
using Fiap.Api.FinancaFacil.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.FinancaFacil.Data.Repository
{
    public class ExampleRepository : IExampleRepository
    {

        private readonly DatabaseContext _context;

        public ExampleRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IList<ExampleModel>> GetAll(int lastReference, int size)
        {
            return await _context.Examples
                .AsNoTracking()
                .Where(c => c.Id > lastReference)
                .OrderBy( c => c.Id) 
                .Take(size + 1)
                .ToListAsync();
        }

        public async Task<ExampleModel?> GetById(int id) => await _context.Examples.FindAsync(id);

        public async Task Add(ExampleModel example)
        {
            _context.Examples.Add(example);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ExampleModel example)
        {
            _context.Examples.Update(example);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ExampleModel example)
        {
            _context.Examples.Remove(example);
            await _context.SaveChangesAsync();
        }
    }
}
