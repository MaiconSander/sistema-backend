using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using ProgramacaoDoZero.modelss;
using ProgramacaoDoZero.Service;
using System.Runtime.InteropServices;


namespace ProgramacaoDoZero.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IConfiguration _configuration;
         public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [Route("login")]
        [HttpPost]
        public LoginResult Login(modelss.LoginRequest request)
        {
            var result = new LoginResult();

            if (request == null)
            {
                result.sucesso = false;
                result.mensagem = "Parametro request veio nulo.";
            }
            else if (request.email == "")
            {
                result.sucesso = false;
                result.mensagem = "E-mail obrigatorio";
            }
            else if (request.senha == "")
            {
                result.sucesso = false;
                result.mensagem = "Senha obrigatória";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");
                var usuarioService = new UsuarioService(connectionString);

                result = usuarioService.Login(request.email, request.senha);
            }

            return result;
        }

        [Route("cadastro")]
        [HttpPost]
        public CadastroResult Cadastro(CadastroRequest request)
        {
            var result = new CadastroResult();

            if (request == null ||
                string.IsNullOrEmpty(request.nome) ||
                string.IsNullOrEmpty(request.sobrenome) ||
                string.IsNullOrEmpty(request.telefone) ||
                string.IsNullOrEmpty(request.genero) ||
                string.IsNullOrEmpty(request.email) ||
                string.IsNullOrEmpty(request.senha))
            {
                result.sucesso = false;
                result.mensagem = "Todos os campos são obrigatórios";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");

                var usuarioService = new UsuarioService(connectionString);

                result = usuarioService.Cadastro(request.nome, request.sobrenome, request.telefone,
                    request.email, request.genero, request.senha);
            }
            result.sucesso = true;
            result.mensagem = "Cadastro realizado com sucesso";

            return result;
        }

        [Route("esqueceuSenha")]
        [HttpPost]
        public EsqueceuSenhaResult EsqueceuSenha(EsqueceuSenhaRequest request)
        {
            var result = new EsqueceuSenhaResult();

            if (request == null ||
                string.IsNullOrEmpty(request.email))
            {
                
                result.mensagem = "Email obrigatório";

                return result;
            }

            var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");

            var mensagem = new UsuarioService(connectionString).EsqueceuSenha(request.email);

            if (!string.IsNullOrEmpty(mensagem))
            {
                result.sucesso = false;
                result.mensagem = "Erro ao enviar email";
            }
            else
            {
                result.sucesso = true;
            }
            
            return result;
            
        }

        [HttpGet]
        [Route("obterUsuario")]
        public ObterUsuarioResult ObterUsuarioResult(Guid usuarioGuid)
        {
            var result = new ObterUsuarioResult();

            if (usuarioGuid == null)
            {
                result.mensagem = "Guid vazio";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");

                var usuario = new UsuarioService(connectionString).obterUsuario(usuarioGuid);

                if (usuario == null)
                {
                    result.mensagem = "Usuario não existe";
                }
                else
                {
                    result.sucesso = true;
                    result.nome = usuario.Nome; 
                }
            }   

            return result;

        }
    }
}
