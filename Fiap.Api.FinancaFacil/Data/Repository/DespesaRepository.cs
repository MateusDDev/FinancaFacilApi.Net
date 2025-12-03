using Fiap.Api.FinancaFacil.Data.Contexts;
using Fiap.Api.FinancaFacil.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.FinancaFacil.Data.Repository;

public class DespesaRepository : IDespesaRepository
{
    private readonly DatabaseContext _context;

    public DespesaRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IList<DespesaModel>> GetAll(int lastReference, int size)
    {
        return await _context.Despesas
            .AsNoTracking()
            .Where(c => c.IdDespesa > lastReference)
            .OrderBy(c => c.IdDespesa)
            .Take(size + 1)
            .ToListAsync();
    }

    public async Task<DespesaModel?> GetById(int id) 
        => await _context.Despesas.FindAsync(id);

    public async Task Add(DespesaModel model)
    {
        _context.Despesas.Add(model);
        await _context.SaveChangesAsync();
    }

    public async Task Update(DespesaModel model)
    {
        _context.Despesas.Update(model);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(DespesaModel model)
    {
        _context.Despesas.Remove(model);
        await _context.SaveChangesAsync();
    }
}