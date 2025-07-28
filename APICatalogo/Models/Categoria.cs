using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Models;

[Table("Categorias")]
public class Categoria
{
    public Categoria()
    {
        Produtos = new Collection<Produto>();
    }
    [Key]
    public Guid CategoriaId { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
    public string? Nome { get; set; }

    public string? ImagemUrl { get; set; }
    public DateTime DataCadastro { get; set; } = DateTime.Now;

    public ICollection<Produto>? Produtos { get; set; }
}
