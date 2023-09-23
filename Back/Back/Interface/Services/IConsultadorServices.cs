namespace Back.Interface.Services;

public interface IConsultadorServices : IScoped
{
    string RetornarDadosRequest(string url);
}