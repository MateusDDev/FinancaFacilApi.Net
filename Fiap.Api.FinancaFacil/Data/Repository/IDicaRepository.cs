using Fiap.Api.FinancaFacil.Models;

public interface IDicaRepository
{
    Task<IList<DicaModel>> GetAll();
    Task<IList<DicaModel>> GetByCategoria(string categoria);
}