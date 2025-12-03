using AutoMapper;
using Fiap.Api.FinancaFacil.Controllers;
using Fiap.Api.FinancaFacil.Models;
using Fiap.Api.FinancaFacil.Services;
using Fiap.Api.FinancaFacil.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Fiap.Api.FinancaFacil.Tests;

public sealed class DespesaControllerTests
{
    private readonly Mock<IDespesaService> _mockService;
    private readonly Mock<IMapper> _mockMapper;
    private readonly DespesaController _mockController;

    public DespesaControllerTests()
    {
        _mockMapper = new Mock<IMapper>();
        _mockService = new Mock<IDespesaService>();
        _mockController = new DespesaController(_mockService.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task Get_ReturnsOkResult_WithListDespesaViewModel()
    {
        // Arrange
        var serviceExamples = new List<DespesaModel>
        {
            new()
            {
                IdDespesa = 1,
                IdUsuario = 1,
                Categoria = "Transporte",
                Valor = 50.75m,
                Data = new DateTime(2025, 1, 10)
            },
            new()
            {
                IdDespesa = 2,
                IdUsuario = 2,
                Categoria = "Alimentação",
                Valor = 32.40m,
                Data = new DateTime(2025, 1, 11)
            }
        };

        _mockService.Setup(s => s.GetDespesas(0, 10))
            .ReturnsAsync(serviceExamples);

        _mockMapper.Setup(m => m.Map<IList<DespesaViewModel>>(It.IsAny<IList<DespesaModel>>()))
            .Returns(serviceExamples.Select(d => new DespesaViewModel
            {
                IdDespesa = d.IdDespesa,
                IdUsuario = d.IdUsuario,
                Categoria = d.Categoria,
                Valor = d.Valor,
                Data = d.Data
            }).ToList());

        // Act
        var actionResult = await _mockController.List();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var model = Assert.IsType<ListDespesasViewModel>(okResult.Value);

        Assert.Equal(2, model.Despesas.Count());
        Assert.Equal(10, model.PageSize);
        Assert.Null(model.NextCursor);
    }
}