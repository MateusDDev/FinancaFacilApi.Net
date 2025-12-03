using Microsoft.AspNetCore.Mvc;
using Fiap.Api.FinancaFacil.Data.Contexts;

namespace Fiap.Api.FinancaFacil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public HealthController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("db")]
        public IActionResult TestDatabase()
        {
            try
            {
                _context.Database.CanConnect();
                return Ok("Conexão com o Oracle bem-sucedida!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao conectar: {ex.Message}");
            }
        }
    }
}
