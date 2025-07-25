using System.Collections.ObjectModel;

namespace APICatalogo.Models;

public class Categoria
{
    public Categoria()
    {
        Produtos = new Collection<Produto>();
    }
    public Guid CategoriaId { get; set; }
    public string? Nome { get; set; }
    public string? ImagemUrl { get; set; }
    public DateTime DataCadastro { get; set; } = DateTime.Now;

    public ICollection<Produto>? Produtos { get; set; }
}
