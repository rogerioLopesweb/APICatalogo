using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Models;

[Table("Produtos")]
public class Produto
{
    [Key]
    public Guid ProdutoId { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
    public string? Nome { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(300, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
    public string? Descricao { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Column(TypeName ="decimal(10,2)")]
    public decimal Preco { get; set; }
    public string? ImagemUrl { get; set; }
    public float Estoque { get; set; }
    public DateTime DataCadastro { get; set; } = DateTime.Now;

    public Guid CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }

    }
