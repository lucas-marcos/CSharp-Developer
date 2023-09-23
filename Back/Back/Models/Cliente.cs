namespace Back.Models;

public class Cliente : Entity
{
    public string Codigo { get; private set; }
    public string Nome { get; private set; }

    public Cliente(string codigo, string nome)
    {
    }
}