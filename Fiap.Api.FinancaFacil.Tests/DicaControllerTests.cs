using AutoMapper;
using Fiap.Api.FinancaFacil.Controllers;
using Fiap.Api.FinancaFacil.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using Fiap.Api.FinancaFacil.Models;
using Fiap.Api.FinancaFacil.ViewModel;

public class DicaControllerTests
{
    [Fact]
    public async Task GetDicaDiaria_Returns200()
    {
        var mockService = new Mock<IDicaService>();
        var mockMapper = new Mock<IMapper>();

        mockService
            .Setup(s => s.GetDicaDiaria())
            .ReturnsAsync(new DicaModel { IdDica = 1, Texto = "Teste", Categoria = "X" });

        mockMapper
            .Setup(m => m.Map<DicaViewModel>(It.IsAny<DicaModel>()))
            .Returns(new DicaViewModel { IdDica = 1, Texto = "Teste", Categoria = "X" });

        var controller = new DicaController(mockService.Object, mockMapper.Object);

        var result = await controller.GetDicaDiaria();

        var ok = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(200, ok.StatusCode);
    }
}