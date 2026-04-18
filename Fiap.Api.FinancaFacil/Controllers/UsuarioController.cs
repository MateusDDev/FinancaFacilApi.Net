using AutoMapper;
using Fiap.Api.FinancaFacil.Models;
using Fiap.Api.FinancaFacil.Services;
using Fiap.Api.FinancaFacil.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.FinancaFacil.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _service;
    private readonly IMapper _mapper;

    public UsuarioController(IUsuarioService exampleService, IMapper mapper)
    {
        _service = exampleService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<ListUsuariosViewModel>> List(
        [FromQuery] int cursor = 0,
        [FromQuery] int size = 10)
    {
        var serviceExamples = await _service.GetUsuarios(cursor, size);
        
        var hasMore = serviceExamples.Count > size;
        
        var examples = hasMore ? serviceExamples.Take(size).ToList() : serviceExamples;
        
        int? nextCursor = examples.Count == size
            ? examples.Last().IdUsuario
            : null;
        
        var viewModelList = _mapper.Map<IList<UsuarioViewModel>>(examples);

        var viewModel = new ListUsuariosViewModel
        {
            Usuarios = viewModelList,
            PageSize = size,
            NextCursor = nextCursor
        };

        return Ok(viewModel);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<UsuarioViewModel>> Get(int id)
    {
        var usuario = await _service.GetUsuarioById(id);
        
        if (usuario is null)
            return NotFound();
        
        var viewModel = _mapper.Map<UsuarioViewModel>(usuario);
        
        return Ok(viewModel);
    }
    
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] InputUsuarioViewModel viewModel)
    {
        var usuario = _mapper.Map<UsuarioModel>(viewModel);
        
        await _service.CreateUsuario(usuario);
        
        return CreatedAtAction(nameof(Get), new { id = usuario.IdUsuario }, viewModel);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] InputUsuarioViewModel viewModel)
    {
        var usuario = await _service.GetUsuarioById(id);
        
        if (usuario is null)
            return NotFound();
        
        _mapper.Map(viewModel, usuario);
        
        await _service.UpdateUsuario(usuario);
        
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _service.DeleteUsuario(id);
        return NoContent();
    }
}