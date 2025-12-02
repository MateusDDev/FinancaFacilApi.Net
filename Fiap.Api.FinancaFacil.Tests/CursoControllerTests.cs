using AutoMapper;
using Fiap.Api.FinancaFacil.Controllers;
using Fiap.Api.FinancaFacil.Models;
using Fiap.Api.FinancaFacil.Services;
using Fiap.Api.FinancaFacil.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Fiap.Api.FinancaFacil.Tests;

public sealed class CursoControllerTests
{
    private readonly Mock<ICursoService> _mockService;
    private readonly Mock<IMapper> _mockMapper;
    private readonly CursoController _mockController;

    public CursoControllerTests()
    {
        _mockMapper = new Mock<IMapper>();
        _mockService = new Mock<ICursoService>();
        _mockController = new CursoController(_mockService.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task Get_ReturnsOkResult_WithListCursosViewModel()
    {
        // Arrange
        var serviceExamples = new List<CursoModel>
        {
            new()
            {
                Id = 1,
                CargaHoraria = 20,
                Categoria = "Investimentos",
                Descricao = "Descrição do curso",
                Nivel = "Iniciante",
                DtCriacao = new DateTime(2025, 11, 30),
                Nome = "Curso de investimentos"
            },
            new()
            {
                Id = 1,
                CargaHoraria = 20,
                Categoria = "Administração",
                Descricao = "Descrição altamente descritiva",
                Nivel = "Intermediario",
                DtCriacao = new DateTime(2025, 09, 30),
                Nome = "Curso de administração"
            }
        };

        _mockService.Setup(s => s.GetCursos(0, 10))
            .ReturnsAsync(serviceExamples);

        _mockMapper.Setup(m => m.Map<IList<CursoViewModel>>(It.IsAny<IList<CursoModel>>()))
            .Returns(serviceExamples.Select(_ => new CursoViewModel 
            {
                Id = 1,
                CargaHoraria = 20,
                Categoria = "Investimentos",
                Descricao = "Descrição do curso",
                Nivel = "Iniciante",
                DtCriacao = new DateTime(2025, 11, 30),
                Nome = "Curso de investimentos"
            }).ToList());

        // Act
        var actionResult = await _mockController.List();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var model = Assert.IsType<ListCursosViewModel>(okResult.Value);

        Assert.Equal(2, model.Cursos.Count());
        Assert.Equal(10, model.PageSize);
        Assert.Null(model.NextCursor);
    }
}