
namespace FocinhosFelizes1.Models
{
    public class Produtos
    {
        public Guid ProdutosId { get; set; }
        public string NomeCategoria { get; set; }

        public Guid CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        public string DescricaoProduto { get; set; }
    }
}
