using AutoMapper;
using Fiap.Api.FinancaFacil.Controllers;
using Fiap.Api.FinancaFacil.Models;
using Fiap.Api.FinancaFacil.Services;
using Fiap.Api.FinancaFacil.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Fiap.Api.FinancaFacil.Tests;

public sealed class RendaControllerTests
{
    private readonly Mock<IRendaService> _mockService;
    private readonly Mock<IMapper> _mockMapper;
    private readonly RendaController _mockController;

    public RendaControllerTests()
    {
        _mockMapper = new Mock<IMapper>();
        _mockService = new Mock<IRendaService>();
        _mockController = new RendaController(_mockService.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task Get_ReturnsOkResult_WithListRendasViewModel()
    {
        // Arrange
        var serviceExamples = new List<RendaModel>
        {
            new()
            {
                IdRenda =1,
                IdUsuario = 1, 
                CdRenda = 1,
                TpRenda = "Salário", 
                VlRenda = 10000
            },
            new()
            {
                IdRenda =2,
                IdUsuario = 2, 
                CdRenda = 2,
                TpRenda = "Investimento", 
                VlRenda = 20000
            },
        };

        _mockService.Setup(s => s.GetRendas(0, 10))
            .ReturnsAsync(serviceExamples);

        _mockMapper.Setup(m => m.Map<IList<RendaViewModel>>(It.IsAny<IList<RendaModel>>()))
            .Returns(serviceExamples.Select(_ => new RendaViewModel {
                IdRenda =1,
                IdUsuario = 1, 
                CdRenda = 1,
                TpRenda = "Salário", 
                VlRenda = 10000
            }).ToList());

        // Act
        var actionResult = await _mockController.List();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var model = Assert.IsType<ListRendasViewModel>(okResult.Value);

        Assert.Equal(2, model.Renda.Count());
        Assert.Equal(10, model.PageSize);
        Assert.Null(model.NextCursor);
    }
}