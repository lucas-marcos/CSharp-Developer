namespace Back.Models;

public class Cliente : Entity
{
    public string Codigo { get; private set; }
    public string Nome { get; private set; }

    public Cliente(int id, string codigo, string nome)
    {
        Id = id;
        Codigo = codigo;
        Nome = nome;
    }
}