﻿namespace APICatalogo.Models;

public class Produto
{
    public Guid ProdutoId { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public decimal Preco { get; set; }
    public string? ImagemUrl { get; set; }
    public float Estoque { get; set; }
    public DateTime DataCadastro { get; set; } = DateTime.Now;

    public Guid CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }

    }
