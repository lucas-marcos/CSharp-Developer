using Back.Interface.Services;

namespace Back.Services;

public class ConsultadorServices : IConsultadorServices
{
    private HttpClient _client = new HttpClient();

    public string RetornarDadosRequest(string url)
    {
        return _client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
    }
}