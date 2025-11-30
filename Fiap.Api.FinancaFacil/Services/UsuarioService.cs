using Fiap.Api.FinancaFacil.Data.Repository;
using Fiap.Api.FinancaFacil.Models;

namespace Fiap.Api.FinancaFacil.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repository;

    public UsuarioService(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<IList<UsuarioModel>> GetUsuarios(int lastReference, int size)
    {
        return await _repository.GetAll(lastReference, size);
    }

    public async Task<UsuarioModel?> GetUsuarioById(int id) => await _repository.GetById(id);

    public Task CreateUsuario(UsuarioModel usuario) => _repository.Add(usuario);

    public Task UpdateUsuario(UsuarioModel usuario) => _repository.Update(usuario);

    public async Task DeleteUsuario(int id)
    {
        var usuario = await _repository.GetById(id);
            
        if (usuario is not null)
            await _repository.Delete(usuario);
    }
}