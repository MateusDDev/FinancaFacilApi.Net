using Fiap.Api.FinancaFacil.Data.Contexts;
using Fiap.Api.FinancaFacil.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.FinancaFacil.Data.Repository;

public class CursoRepository : ICursoRepository
{
    private readonly DatabaseContext _context;

    public CursoRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IList<CursoModel>> GetAll(int lastReference, int size)
    {
        return await _context.Cursos
            .AsNoTracking()
            .Where(c => c.Id > lastReference)
            .OrderBy( c => c.Id) 
            .Take(size + 1)
            .ToListAsync();
    }

    public async Task<CursoModel?> GetById(int id) => await _context.Cursos.FindAsync(id);

    public async Task Add(CursoModel curso)
    {
        _context.Cursos.Add(curso);
        await _context.SaveChangesAsync();
    }

    public async Task Update(CursoModel curso)
    {
        _context.Cursos.Update(curso);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(CursoModel curso)
    {
        _context.Cursos.Remove(curso);
        await _context.SaveChangesAsync();
    }
}