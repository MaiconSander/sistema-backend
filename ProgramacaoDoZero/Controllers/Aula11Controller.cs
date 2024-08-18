
using Microsoft.AspNetCore.Mvc;
using ProgramacaoDoZero.Models;

namespace ProgramacaoDoZero.Controllers
{
    [Route("api/Aula11")]
    [ApiController]
    public class Aula11Controller : ControllerBase
    {
        [Route("obterVeiculo")]
        [HttpGet]
        public Veiculo obterVeiculo()
        {
            var meuVeiculo = new Veiculo();

            meuVeiculo.Cor = "preto";
            meuVeiculo.Marca = "fiat";
            meuVeiculo.Modelo = "uno";
            meuVeiculo.Placa = "CXE-9876";

            meuVeiculo.Acelerar();

            return meuVeiculo;
        }

        [Route("obterCarro")]
        [HttpGet]

        public Carro obterCarro()
        {
            var meuCarro = new Carro();

            meuCarro.Marca = "Honda";
            meuCarro.Modelo = "fiat";
            meuCarro.Cor = "azul";
            meuCarro.Placa = "HYZ-2346";

            meuCarro.Acelerar();

            return meuCarro;
        }

        [Route("obterMoto")]
        [HttpGet]
        public Moto obterMoto()
        {
            var minhaMoto = new Moto();

            minhaMoto.Marca = "Honda";
            minhaMoto.Cor = "cinza";
            minhaMoto.Modelo = "160";
            minhaMoto.Placa = "AFD-239";

            minhaMoto.Acelerar();

            return minhaMoto;
        }
    }
}
