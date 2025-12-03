using Fiap.Api.FinancaFacil.Models;
using Fiap.Api.FinancaFacil.ViewModel;
using Microsoft.EntityFrameworkCore;
using Fiap.Api.FinancaFacil.Data.Contexts;

namespace Fiap.Api.FinancaFacil.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly DatabaseContext _context;

        public UsuarioService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IList<UsuarioModel>> GetUsuarios(int lastReference, int size)
        {
            return await _context.Usuarios
                .Where(u => u.IdUsuario > lastReference)
                .OrderBy(u => u.IdUsuario)
                .Take(size)
                .ToListAsync();
        }

        public async Task<UsuarioModel?> GetUsuarioById(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<UsuarioModel?> GetUsuarioByEmail(string email)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task CreateUsuario(UsuarioModel usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUsuario(UsuarioModel usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }
    }
}
