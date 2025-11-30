using AutoMapper;
using Fiap.Api.FinancaFacil.Models;
using Fiap.Api.FinancaFacil.Services;
using Fiap.Api.FinancaFacil.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.FinancaFacil.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RendaController : ControllerBase
{
    private readonly IRendaService _service;
    private readonly IMapper _mapper;

    public RendaController(IRendaService exampleService, IMapper mapper)
    {
        _service = exampleService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<ListRendasViewModel>> List(
        [FromQuery] int cursor = 0,
        [FromQuery] int size = 10)
    {
        var serviceExamples = await _service.GetRendas(cursor, size);
        
        var hasMore = serviceExamples.Count > size;
        
        var examples = hasMore ? serviceExamples.Take(size).ToList() : serviceExamples;
        
        int? nextCursor = examples.Count == size
            ? examples.Last().IdUsuario
            : null;
        
        var viewModelList = _mapper.Map<IList<RendaViewModel>>(examples);

        var viewModel = new ListRendasViewModel
        {
            Renda = viewModelList,
            PageSize = size,
            NextCursor = nextCursor
        };

        return Ok(viewModel);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<RendaViewModel>> Get(int id)
    {
        var renda = await _service.GetRendaById(id);
        
        if (renda is null)
            return NotFound();
        
        var viewModel = _mapper.Map<RendaViewModel>(renda);
        
        return Ok(viewModel);
    }
    
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] InputRendaViewModel viewModel)
    {
        var renda = _mapper.Map<RendaModel>(viewModel);
        
        await _service.CreateRenda(renda);
        
        return CreatedAtAction(nameof(Get), new { id = renda.IdRenda }, viewModel);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] InputRendaViewModel viewModel)
    {
        var renda = await _service.GetRendaById(id);
        
        if (renda is null)
            return NotFound();
        
        _mapper.Map(viewModel, renda);
        
        await _service.UpdateRenda(renda);
        
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _service.DeleteRenda(id);
        return NoContent();
    }
}