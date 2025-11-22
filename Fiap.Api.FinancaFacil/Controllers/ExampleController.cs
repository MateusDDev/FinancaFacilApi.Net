using AutoMapper;
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
    public ActionResult<IEnumerable<ExampleViewModel>> Get()
    {
        var examples = _service.GetExamples();
        var viewModelList = _mapper.Map<IEnumerable<ExampleViewModel>>(examples);
        
        return Ok(viewModelList);
    }
    
    [HttpGet("{id}")]
    public ActionResult<ExampleViewModel> Get(int id)
    {
        var example = _service.GetExampleById(id);
        
        if (example is null)
            return NotFound();
        
        var viewModel = _mapper.Map<ExampleViewModel>(example);
        
        return Ok(viewModel);
    }
}