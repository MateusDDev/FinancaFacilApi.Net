using Fiap.Api.FinancaFacil.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Fiap.Api.FinancaFacil.Models;

namespace Fiap.Api.FinancaFacil.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _service;
        private readonly IConfiguration _config;

        public AuthController(IUsuarioService service, IConfiguration config)
        {
            _service = service;
            _config = config;
        }

        public class LoginRequest
        {
            public string Email { get; set; }
            public string Senha { get; set; }
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest request)
        {
            var usuario = await _service.GetUsuarioByEmail(request.Email);

            if (usuario == null)
                return Unauthorized(new { message = "Usuário não encontrado" });

            bool senhaCorreta = BCrypt.Net.BCrypt.Verify(request.Senha, usuario.Senha);

            if (!senhaCorreta)
                return Unauthorized(new { message = "Senha incorreta" });

            var token = GerarJwt(usuario);

            return Ok(new
            {
                message = "Login realizado com sucesso!",
                token,
                usuario = new
                {
                    usuario.IdUsuario,
                    usuario.NmUsuario,
                    usuario.Email
                }
            });
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] UsuarioModel request)
        {
            var usuarioExistente = await _service.GetUsuarioByEmail(request.Email);

            if (usuarioExistente != null)
                return BadRequest(new { message = "Já existe um usuário cadastrado com esse e-mail." });

            string senhaCriptografada = BCrypt.Net.BCrypt.HashPassword(request.Senha);

            var novoUsuario = new UsuarioModel
{
            NmUsuario = request.NmUsuario,
            Email = request.Email,
            Cpf = request.Cpf,
            Celular = request.Celular,
            DtNascimento = request.DtNascimento,
            Senha = senhaCriptografada
};

            await _service.CreateUsuario(novoUsuario);

            return Ok(new
            {
                message = "Usuário cadastrado com sucesso!",
                usuario = new
                {
                    novoUsuario.IdUsuario,
                    novoUsuario.NmUsuario,
                    novoUsuario.Email
                }
            });
        }

        private string GerarJwt(UsuarioModel usuario)
        {
            var keyString = _config["Jwt:Key"]
                ?? throw new InvalidOperationException("A chave 'Jwt:Key' não foi configurada.");

            var issuer = _config["Jwt:Issuer"]
                ?? throw new InvalidOperationException("O emissor 'Jwt:Issuer' não foi configurado.");

            var key = Encoding.UTF8.GetBytes(keyString);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.IdUsuario.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                new Claim("nome", usuario.NmUsuario)
            };

            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: null,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
