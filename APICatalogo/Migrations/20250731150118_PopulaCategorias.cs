using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var dataCadastro = DateTime.Now;

            migrationBuilder.Sql($@"
        INSERT INTO Categorias (CategoriaId, Nome, ImagemUrl, DataCadastro) VALUES
        ('{Guid.NewGuid()}', 'Bebidas', 'https://example.com/imagens/bebidas.jpg', '{dataCadastro:yyyy-MM-dd HH:mm:ss}'),
        ('{Guid.NewGuid()}', 'Alimentos', 'https://example.com/imagens/alimentos.jpg', '{dataCadastro:yyyy-MM-dd HH:mm:ss}'),
        ('{Guid.NewGuid()}', 'Higiene Pessoal', 'https://example.com/imagens/higiene.jpg', '{dataCadastro:yyyy-MM-dd HH:mm:ss}'),
        ('{Guid.NewGuid()}', 'Limpeza', 'https://example.com/imagens/limpeza.jpg', '{dataCadastro:yyyy-MM-dd HH:mm:ss}')
    ");
        }



        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"DELETE FROM Categorias WHERE Nome IN ('Bebidas', 'Alimentos', 'Higiene Pessoal', 'Limpeza')"
            );

        }
    }
}
