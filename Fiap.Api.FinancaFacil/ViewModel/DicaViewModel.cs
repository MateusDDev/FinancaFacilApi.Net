namespace Fiap.Api.FinancaFacil.ViewModel
{
    public class DicaViewModel
    {
        public int IdDica { get; set; }
        public string Texto { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
    }

    public class ListDicasViewModel
    {
        public IList<DicaViewModel> Dicas { get; set; } = new List<DicaViewModel>();
    }
}