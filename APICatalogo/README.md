# 📦 Projeto Catálogo de Produtos e Categorias

API construída com **ASP.NET Core 8**, **Entity Framework Core 8** e **MySQL** como banco de dados relacional.

---

## 📚 Tecnologias utilizadas.

- ASP.NET Core 8
- Entity Framework Core 8
- Pomelo MySQL Provider
- Swagger (Swashbuckle)
- MySQL

---

## 🛠️ Configuração do Banco de Dados

O arquivo `appsettings.json` deve conter sua string de conexão MySQL:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=3306;database=CatalogoDB;user=root;password=suaSenha"
  }
}


##✅ Criar a primeira migration

dotnet ef migrations add MigracaoInicial

##✅ Aplicar a migration no banco de dados
dotnet ef migrations add MigracaoInicial

✅ Aplicar a migration no banco de dados
dotnet ef database update

✅ Remover a última migration (caso necessário)
dotnet ef migrations remove

✅ Criar novas migrations após alterações no modelo
dotnet ef migrations add NomeDaMigration
Exemplo: dotnet ef migrations add AdicionarCampoDescricao

✅ Atualizar banco de dados após nova migration
dotnet ef database update

✅ Listar migrations já criadas
dotnet ef migrations list