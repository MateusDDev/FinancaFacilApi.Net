using Fiap.Api.FinancaFacil.Models;

public interface IDicaService
{
    Task<DicaModel> GetDicaDiaria();
    Task<IList<DicaModel>> GetByCategoria(string categoria);
}