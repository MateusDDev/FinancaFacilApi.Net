using Fiap.Api.FinancaFacil.Data.Contexts;
using Fiap.Api.FinancaFacil.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.FinancaFacil.Data.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly DatabaseContext _context;

    public UsuarioRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IList<UsuarioModel>> GetAll(int lastReference, int size)
    {
        return await _context.Usuarios
            .AsNoTracking()
            .Include(c => c.Rendas)
            .Where(c => c.IdUsuario > lastReference)
            .OrderBy(c => c.IdUsuario)
            .Take(size + 1)
            .ToListAsync();
    }

    public async Task<UsuarioModel?> GetById(int id) 
        => await _context.Usuarios.FindAsync(id);

    public async Task<UsuarioModel?> GetByEmail(string email)
    {
        return await _context.Usuarios
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task Add(UsuarioModel usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task Update(UsuarioModel usuario)
    {
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(UsuarioModel usuario)
    {
        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();
    }
}
