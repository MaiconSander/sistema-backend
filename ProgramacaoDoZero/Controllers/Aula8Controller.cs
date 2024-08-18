using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProgramacaoDoZero.Controllers
{
    [Route("api/aula8")]
    [ApiController]
    public class Aula8Controller : ControllerBase
    {
        [Route("ola-mundo")]
        [HttpGet]

        public string Olamundo()
        {
            var mensagem = "Olá mundo via API";

            return mensagem;
        }

        [Route("olamundoPersonalizado")]
        [HttpGet]

        public string OlamundoPersonalizado(string nome)  
        {
            var mensagem = "Olá mundo via API " + nome;

            return mensagem;
        }

        [Route("somar")]
        [HttpGet]

        public string Somar (int valor1, int valor2)
        {
            var soma = valor1 + valor2;

            var mensagem = " A soma é " + soma;

            return mensagem;
        }

        [Route("Media")]
        [HttpGet]

        public string Media (int numero1, int numero2)
        {
            var media = numero1 + numero2;

            var mensagem = "A media é " + media;

            return mensagem;

        }

        [Route("Terreno")]
        [HttpGet]
        
        public IActionResult Terreno(decimal largura, decimal comprimento, decimal valorM2)
        {
            var areaTerreno = largura * comprimento;

            var valorTerreno = areaTerreno * valorM2;

            var mensagem = "A area do terreno é de " + areaTerreno + "m2. O valor do terreno é de R$ " + valorTerreno;

            return Ok(mensagem);
        }

        [Route("Troco")]
        [HttpGet]

        public IActionResult Troco(decimal preçoUnitario, int quantidade, decimal valorPago)
        {
            var precoTotal = preçoUnitario * quantidade;

            var troco = valorPago - precoTotal;

            var mensagem = " O troco do cliente é de " + troco; 

            return Ok(mensagem); 
        }

        [Route("Pagamento")]
        [HttpGet]
        public IActionResult Pagamento(int funcionario, decimal valorHora, decimal QuantidadeHora)
        {
            var valorTotal = funcionario * valorHora;

            var valorhora = QuantidadeHora * valorTotal;

            var mensagem = " O pagamento é de " + valorhora + valorTotal;

            return Ok(mensagem);
        }

        public IActionResult Consumo(decimal Distancia, decimal Combustivel)
        {
            var valorCombustivel = Distancia + Combustivel;

            var totalDistancia = valorCombustivel + Distancia;

            var mensagem = "O consumo medio do veiculo é de " + valorCombustivel + totalDistancia;

            return Ok(mensagem);
        }
    }
}
