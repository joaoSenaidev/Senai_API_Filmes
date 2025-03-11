using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using API_Filmes_senai.Domains;
using API_Filmes_senai.DTO;
using API_Filmes_senai.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace API_Filmes_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        /// <summary>
        /// Login do Usuario
        /// </summary>
        /// <param name="loginDTO">Email e Senha do Usuario</param>
        /// <returns>Usuario</returns>
        [HttpPost]
        public IActionResult Login(LoginDTO loginDTO)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(loginDTO.Email!, loginDTO.Senha!);

                if (usuarioBuscado == null)
                {
                    return NotFound("Usuario nao encontrado, email ou senha invalidos");
                }
                //caso o usuario seja encontrado, prossegue para a criacao do token

                //1 Passo - definir as claims() que serao fornecidos no token

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,usuarioBuscado.Email!),
                    new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.Nome!),

                    //podemos definir uma claim personalizada
                    new Claim("Nome da claim","Valor da claim")

                };
                //2 Passo - definir a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev"));

                //3 Passo - definir as credenciais do token (header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4 passo - gerar o token
                var token = new JwtSecurityToken(
                    //emisor do token
                    issuer: "API_Filmes_senai",

                    //destinatario do token
                    audience: "API_Filmes_senai",

                    //dados definidos nas claims
                    claims: claims,

                    //tempo de expiracao do token
                    expires: DateTime.Now.AddMinutes(5),

                    //credenciais do token
                    signingCredentials: creds

                 );
                return Ok(
                    new { 
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    }
                    );

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

















    }
}
