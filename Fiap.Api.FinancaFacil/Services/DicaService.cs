using Fiap.Api.FinancaFacil.Models;

public class DicaService : IDicaService
{
    private readonly IDicaRepository _repo;

    public DicaService(IDicaRepository repo)
    {
        _repo = repo;
    }

    public async Task<DicaModel> GetDicaDiaria()
    {
        var dicas = await _repo.GetAll();

        var index = DateTime.Now.Day % dicas.Count;

        return dicas[index];
    }

    public async Task<IList<DicaModel>> GetByCategoria(string categoria)
    {
        return await _repo.GetByCategoria(categoria);
    }
}