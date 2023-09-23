namespace Back.Models;

public class Produto : Entity
{
    public string Codigo { get; private set; }
    public string Nome { get; private set; }
    public decimal PrecoUnitario { get; private set; }
    public string ImagemUrl { get; private set; }

    public Produto(string codigo, string nome, decimal precoUnitario, string imagemUrl)
    {
        Codigo = codigo;
        Nome = nome;
        PrecoUnitario = precoUnitario;
        ImagemUrl = imagemUrl;
    }
}