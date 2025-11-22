using AutoMapper;
using Fiap.Api.FinancaFacil.Models;
using Fiap.Api.FinancaFacil.Services;
using Fiap.Api.FinancaFacil.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.FinancaFacil.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExampleController : ControllerBase
{
    private readonly IExampleService _service;
    private readonly IMapper _mapper;

    public ExampleController(IExampleService exampleService, IMapper mapper)
    {
        _service = exampleService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<ListExamplesViewModel>> Get(
        [FromQuery] int cursor = 0,
        [FromQuery] int size = 10)
    {
        var serviceExamples = await _service.GetExamples(cursor, size);
        
        var hasMore = serviceExamples.Count > size;
        
        var examples = hasMore ? serviceExamples.Take(size).ToList() : serviceExamples;
        
        int? nextCursor = examples.Count == size
            ? examples.Last().Id
            : null;
        
        var viewModelList = _mapper.Map<IList<ExampleViewModel>>(examples);

        var viewModel = new ListExamplesViewModel
        {
            Examples = viewModelList,
            PageSize = size,
            NextCursor = nextCursor,
        };

        return Ok(viewModel);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ExampleViewModel>> Get(int id)
    {
        var example = await _service.GetExampleById(id);
        
        if (example is null)
            return NotFound();
        
        var viewModel = _mapper.Map<ExampleViewModel>(example);
        
        return Ok(viewModel);
    }
    
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] InputExampleViewModel viewModel)
    {
        var example = _mapper.Map<ExampleModel>(viewModel);
        
        await _service.CreateExample(example);
        
        return CreatedAtAction(nameof(Get), new { id = example.Id }, viewModel);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] InputExampleViewModel viewModel)
    {
        var example = await _service.GetExampleById(id);
        
        if (example is null)
            return NotFound();
        
        _mapper.Map(viewModel, example);
        
        await _service.UpdateExample(example);
        
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _service.DeleteExample(id);
        return NoContent();
    }
}