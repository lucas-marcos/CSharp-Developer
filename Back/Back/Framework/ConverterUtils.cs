using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Back.Framework;

public static class ConverterUtils
{
    public static T FromJson<T>(this string objetoParaSerSerializado)
    {
        return objetoParaSerSerializado == null ? default : JsonConvert.DeserializeObject<T>(objetoParaSerSerializado);
    }
    public static T FromJsonIgnoreId<T>(this string objetoParaSerSerializado)
	{
		if (string.IsNullOrWhiteSpace(objetoParaSerSerializado) ) return default;

		JToken token = JToken.Parse(objetoParaSerSerializado);

		if (token.Type == JTokenType.Object)
		{
			JObject jsonObject = (JObject)token;
			jsonObject.Remove("id");

			return jsonObject.ToString().FromJson<T>();
		}

		if (token.Type == JTokenType.Array)
		{
			var jsonArray = (JArray)token;

			foreach (JObject jsonObject in jsonArray)
			{
				jsonObject.Remove("id");
			}

			return jsonArray.ToString().FromJson<T>();
		}

		return default;
	}
    
}