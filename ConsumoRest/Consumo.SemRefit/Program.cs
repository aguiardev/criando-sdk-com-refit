using FipeSdkSemRefit;
using System.Text.Json;

Console.WriteLine("Exemplo de consumo REST (Sem Refit)");

var fipeSdk = new FipeSdk();

var resultado = await fipeSdk.GetVeiculoAsync(23, 8886, "2022-1");

var resultadoSerializado = JsonSerializer.Serialize(resultado);

Console.WriteLine(resultadoSerializado);