using AutoMapper;
using Fiap.Api.FinancaFacil.ViewModel;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DicaController : ControllerBase
{
    private readonly IDicaService _service;
    private readonly IMapper _mapper;

    public DicaController(IDicaService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    /// <summary>Retorna a "dica do dia" baseada na data.</summary>
    [HttpGet("diaria")]
    public async Task<ActionResult<DicaViewModel>> GetDicaDiaria()
    {
        var dica = await _service.GetDicaDiaria();
        return Ok(_mapper.Map<DicaViewModel>(dica));
    }

    /// <summary>Retorna todas as dicas de uma categoria.</summary>
    [HttpGet("{categoria}")]
    public async Task<ActionResult<ListDicasViewModel>> GetPorCategoria(string categoria)
    {
        var dicas = await _service.GetByCategoria(categoria);

        if (dicas.Count == 0)
            return NotFound("Nenhuma dica encontrada para essa categoria.");

        var vm = new ListDicasViewModel
        {
            Dicas = _mapper.Map<IList<DicaViewModel>>(dicas)
        };

        return Ok(vm);
    }
}