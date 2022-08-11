using FipeSdkComRefit;
using Refit;
using System.Text.Json;

Console.WriteLine("Exemplo de consumo REST (Com Refit)");

var fipeSdk = RestService.For<IFipeSdk>("https://parallelum.com.br");

var resultado = await fipeSdk.GetVeiculoAsync(23, 8886, "2022-1");

var resultadoSerializado = JsonSerializer.Serialize(resultado);

Console.WriteLine(resultadoSerializado);