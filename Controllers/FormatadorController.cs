using Formatador_CPF_CNPJ.Entities;
using Formatador_CPF_CNPJ.Services;
using Microsoft.AspNetCore.Mvc;

namespace Formatador_CPF_CNPJ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormatadorController : ControllerBase
    {
        private readonly FormatadorService _formatadorService;

        public FormatadorController(FormatadorService formatadorService)
        {
            _formatadorService = formatadorService;
        }

        [HttpPost("formatarCpfCnpj")]
        public IActionResult FormatarCpfCnpj([FromBody] DadosEntrada _dadosEntrada)
        {
            return Ok(_formatadorService.FormatarCpfCnpj(_dadosEntrada));
        }
    }
}
