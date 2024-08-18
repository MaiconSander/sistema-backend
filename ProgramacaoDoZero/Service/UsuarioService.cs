using ProgramacaoDoZero.Common;
using ProgramacaoDoZero.Entities;
using ProgramacaoDoZero.modelss;
using ProgramacaoDoZero.Repositories;

namespace ProgramacaoDoZero.Service
{
    public class UsuarioService
    {
        private string _connectionString;

        public UsuarioService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public LoginResult Login(string email, string senha)
        {
            var result = new LoginResult();

            var usuarioRepository = new UsuarioRepositry(_connectionString);

            var usuario = usuarioRepository.ObterUsuarioPorEmail(email);

            if (usuario != null)
            {
                //usuario existe
                if (usuario.Senha == senha)
                {
                    //senha válida
                    result.sucesso = true;
                    result.usuarioGuid = usuario.UsuarioGuid;
                }
                else
                {
                    //senha inválida
                    result.sucesso = false;
                    result.mensagem = "Usuario ou senha inválido";
                }
            }
            else
            {
                //usuario não existe
                result.sucesso = false;
                result.mensagem = "Usuario ou senha inválidos";
            }

            return result;
        }

        public CadastroResult Cadastro(string nome, string sobrenome, string telefone,
            string email, string genero, string senha)
        {
            var result = new CadastroResult();

            var usuarioRepository = new UsuarioRepositry(_connectionString);

            var usuario = usuarioRepository.ObterUsuarioPorEmail(email);

            if (usuario != null)
            {
                //usuario já existe
                result.sucesso = false;
                result.mensagem = "Usuario já existe no sistema";
            }
            else
            {
                //usuario não existe
                usuario = new Usuario();
                usuario.Nome = nome;
                usuario.Sobrenome = sobrenome;
                usuario.Telefone = telefone;
                usuario.Email = email;
                usuario.Genero = genero;
                usuario.Senha = senha;
                usuario.UsuarioGuid = Guid.NewGuid();

                var insertResult = usuarioRepository.Inserir(usuario);

                if (insertResult > 0)
                {
                    //inseriu com sucesso
                    result.sucesso = true;
                    result.usuarioGuid = usuario.UsuarioGuid;
                }
                else
                {
                    //erro ao inserir
                    result.sucesso = false;
                    result.mensagem = "Erro ao inserir usuário. Tente novamente";
                }
            }   

            return result;
        }

        public string EsqueceuSenha(string email)
        {
            var mensagem = string.Empty;

            var usuario = new UsuarioRepositry(_connectionString).ObterUsuarioPorEmail(email);

            if (usuario == null)
            {
                mensagem = "Usuario não existe";
            }
            else
            {
                var assunto = " Programaçãõ do Zero - Recuperação de Senha ";
                
                var corpo = "Sua senha de acesso é " + usuario.Senha;
                
                var emailSender = new EmailSender();
                
                emailSender.Enviar(assunto, corpo, usuario.Email);
            }

            return mensagem;
        }

        public Usuario obterUsuario(Guid usuarioGuid)
        {
            var usuario = new UsuarioRepositry(_connectionString).ObterPorGuid(usuarioGuid);

            return usuario;
        }
    }
}




