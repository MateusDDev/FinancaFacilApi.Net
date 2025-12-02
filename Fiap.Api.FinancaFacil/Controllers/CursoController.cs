using AutoMapper;
using Fiap.Api.FinancaFacil.Models;
using Fiap.Api.FinancaFacil.Services;
using Fiap.Api.FinancaFacil.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.FinancaFacil.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CursoController : ControllerBase
{
    private readonly ICursoService _service;
    private readonly IMapper _mapper;

    public CursoController(ICursoService cursoService, IMapper mapper)
    {
        _service = cursoService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<ListCursosViewModel>> List(
        [FromQuery] int cursor = 0,
        [FromQuery] int size = 10)
    {
        var serviceCursos = await _service.GetCursos(cursor, size);
        
        var hasMore = serviceCursos.Count > size;
        
        var cursos = hasMore ? serviceCursos.Take(size).ToList() : serviceCursos;
        
        int? nextCursor = cursos.Count == size
            ? cursos.Last().Id
            : null;
        
        var viewModelList = _mapper.Map<IList<CursoViewModel>>(cursos);

        var viewModel = new ListCursosViewModel
        {
            Cursos = viewModelList,
            PageSize = size,
            NextCursor = nextCursor
        };

        return Ok(viewModel);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<CursoViewModel>> Get(int id)
    {
        var curso = await _service.GetCursoById(id);
        
        if (curso is null)
            return NotFound();
        
        var viewModel = _mapper.Map<CursoViewModel>(curso);
        
        return Ok(viewModel);
    }
    
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] InputCursoViewModel viewModel)
    {
        var curso = _mapper.Map<CursoModel>(viewModel);
        
        await _service.CreateCurso(curso);
        
        return CreatedAtAction(nameof(Get), new { id = curso.Id }, viewModel);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] InputCursoViewModel viewModel)
    {
        var curso = await _service.GetCursoById(id);
        
        if (curso is null)
            return NotFound();
        
        _mapper.Map(viewModel, curso);
        
        await _service.UpdateCurso(curso);
        
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _service.DeleteCurso(id);
        return NoContent();
    }
}