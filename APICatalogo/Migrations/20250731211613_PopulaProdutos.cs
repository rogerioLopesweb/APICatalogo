using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var dataCadastro = DateTime.Now;

            var sql = $@"
        INSERT INTO Produtos (ProdutoId, Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) VALUES
        ('{Guid.NewGuid()}', 'Coca-Cola 2L', 'Refrigerante Coca-Cola 2 Litros', 7.99, 'https://example.com/imagens/coca-cola-2l.jpg', 100, '{dataCadastro:yyyy-MM-dd HH:mm:ss}', (SELECT CategoriaId FROM Categorias WHERE Nome = 'Bebidas')),
        ('{Guid.NewGuid()}', 'Arroz 5kg', 'Arroz Branco Tipo 1 - Pacote de 5kg', 19.90, 'https://example.com/imagens/arroz-5kg.jpg', 200, '{dataCadastro:yyyy-MM-dd HH:mm:ss}', (SELECT CategoriaId FROM Categorias WHERE Nome = 'Alimentos')),
        ('{Guid.NewGuid()}', 'Sabão em Pó 1kg', 'Sabão em Pó para Lavagem de Roupas - 1kg', 12.50, 'https://example.com/imagens/sabao-em-po-1kg.jpg', 150, '{dataCadastro:yyyy-MM-dd HH:mm:ss}', (SELECT CategoriaId FROM Categorias WHERE Nome = 'Limpeza')),
        ('{Guid.NewGuid()}', 'Shampoo Anticaspa 400ml', 'Shampoo Anticaspa para Todos os Tipos de Cabelo - 400ml', 15.00, 'https://example.com/imagens/shampoo-anticaspa-400ml.jpg', 120, '{dataCadastro:yyyy-MM-dd HH:mm:ss}', (SELECT CategoriaId FROM Categorias WHERE Nome = 'Higiene Pessoal'))
    ";

            migrationBuilder.Sql(sql);
        }



        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Produtos WHERE Nome IN ('Coca-Cola 2L', 'Arroz 5kg', 'Sabão em Pó 1kg', 'Shampoo Anticaspa 400ml'");
        }
    }

}
