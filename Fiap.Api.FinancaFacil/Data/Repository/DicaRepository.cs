using Fiap.Api.FinancaFacil.Models;

public class DicaRepository : IDicaRepository
{
    // Simulando "banco de dados"
    private readonly List<DicaModel> _dicas = new()
    {
        new() { IdDica = 1, Texto = "Gaste menos do que ganha.", Categoria = "Comportamento" },
        new() { IdDica = 2, Texto = "Espere 24h antes de comprar.", Categoria = "Consumo" },
        new() { IdDica = 3, Texto = "Tenha reserva de emergência.", Categoria = "Planejamento" },
        new() { IdDica = 4, Texto = "Pague dívidas caras primeiro.", Categoria = "Juros" }
    };

    public Task<IList<DicaModel>> GetAll()
        => Task.FromResult<IList<DicaModel>>(_dicas);

    public Task<IList<DicaModel>> GetByCategoria(string categoria)
        => Task.FromResult<IList<DicaModel>>(
            _dicas.Where(d => d.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase)).ToList()
        );
}