using FipeSdkSemRefit.Models;
using System.Text.Json;

namespace FipeSdkSemRefit
{
    public class FipeSdk
    {
        public async Task<Veiculo?> GetVeiculoAsync(int codigoMarca, int codigoModelo, string codigoAno)
        {
            const string endpoint = "https://parallelum.com.br/fipe/api/v1/carros/marcas/{0}/modelos/{1}/anos/{2}";

            using var cliente = new HttpClient();

            var resultado = await cliente
                .GetStringAsync(string.Format(endpoint, codigoMarca, codigoModelo, codigoAno));

            return JsonSerializer.Deserialize<Veiculo>(resultado);
        }
    }
}