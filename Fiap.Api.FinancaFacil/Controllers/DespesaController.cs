using AutoMapper;
using Fiap.Api.FinancaFacil.Models;
using Fiap.Api.FinancaFacil.Services;
using Fiap.Api.FinancaFacil.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.FinancaFacil.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DespesaController : ControllerBase
{
    private readonly IDespesaService _service;
    private readonly IMapper _mapper;

    public DespesaController(IDespesaService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<ListDespesasViewModel>> List(
        [FromQuery] int cursor = 0,
        [FromQuery] int size = 10)
    {
        var items = await _service.GetDespesas(cursor, size);

        var hasMore = items.Count > size;
        var page = hasMore ? items.Take(size).ToList() : items;

        int? nextCursor = page.Count == size
            ? page.Last().IdDespesa
            : null;

        var viewItems = _mapper.Map<IList<DespesaViewModel>>(page);

        return Ok(new ListDespesasViewModel
        {
            Despesas = viewItems,
            PageSize = size,
            NextCursor = nextCursor
        });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DespesaViewModel>> Get(int id)
    {
        var item = await _service.GetDespesaById(id);

        if (item is null)
            return NotFound();

        return Ok(_mapper.Map<DespesaViewModel>(item));
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] InputDespesaViewModel viewModel)
    {
        var model = _mapper.Map<DespesaModel>(viewModel);
        
        await _service.CreateDespesa(model);

        return CreatedAtAction(nameof(Get), new { id = model.IdDespesa }, viewModel);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] InputDespesaViewModel viewModel)
    {
        var item = await _service.GetDespesaById(id);

        if (item is null)
            return NotFound();

        _mapper.Map(viewModel, item);

        await _service.UpdateDespesa(item);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _service.DeleteDespesa(id);
        return NoContent();
    }
}