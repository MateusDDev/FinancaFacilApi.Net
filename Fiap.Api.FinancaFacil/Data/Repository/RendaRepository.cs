using Fiap.Api.FinancaFacil.Data.Contexts;
using Fiap.Api.FinancaFacil.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.FinancaFacil.Data.Repository;

public class RendaRepository : IRendaRepository
{
    private readonly DatabaseContext _context;

    public RendaRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IList<RendaModel>> GetAll(int lastReference, int size)
    {
        return await _context.Rendas
            .AsNoTracking()
            .Include(c => c.Usuario)
            .Where(c => c.IdRenda > lastReference)
            .OrderBy( c => c.IdRenda) 
            .Take(size + 1)
            .ToListAsync();
    }

    public async Task<RendaModel?> GetById(int id) => await _context.Rendas.FindAsync(id);

    public async Task Add(RendaModel renda)
    {
        _context.Rendas.Add(renda);
        await _context.SaveChangesAsync();
    }

    public async Task Update(RendaModel renda)
    {
        _context.Rendas.Update(renda);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(RendaModel renda)
    {
        _context.Rendas.Remove(renda);
        await _context.SaveChangesAsync();
    }
}