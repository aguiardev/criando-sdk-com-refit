using FipeSdkComRefit.Models;
using Refit;

namespace FipeSdkComRefit
{
    public interface IFipeSdk
    {
        [Get("/fipe/api/v1/carros/marcas/{codigoMarca}/modelos/{codigoModelo}/anos/{codigoAno}")]
        Task<Veiculo?> GetVeiculoAsync(int codigoMarca, int codigoModelo, string codigoAno);
    }
}