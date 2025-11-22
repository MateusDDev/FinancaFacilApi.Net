using AutoMapper;
using Fiap.Api.FinancaFacil.Controllers;
using Fiap.Api.FinancaFacil.Models;
using Fiap.Api.FinancaFacil.Services;
using Fiap.Api.FinancaFacil.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Fiap.Api.FinancaFacil.Tests;

public sealed class ExampleControllerTests
{
    private readonly Mock<IExampleService> _mockService;
    private readonly Mock<IMapper> _mockMapper;
    private readonly ExampleController _mockController;

    public ExampleControllerTests()
    {
        _mockMapper = new Mock<IMapper>();
        _mockService = new Mock<IExampleService>();
        _mockController = new ExampleController(_mockService.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task Get_ReturnsOkResult_WithListExamplesViewModel()
    {
        // Arrange
        var serviceExamples = new List<ExampleModel>
        {
            new() { Id = 1, Name = "Cliente 1" },
            new() { Id = 2, Name = "Cliente 2" }
        };

        _mockService.Setup(s => s.GetExamples(0, 10))
            .ReturnsAsync(serviceExamples);

        _mockMapper.Setup(m => m.Map<IList<ExampleViewModel>>(It.IsAny<IList<ExampleModel>>()))
            .Returns(serviceExamples.Select(e => new ExampleViewModel { Id = e.Id, Name = e.Name }).ToList());

        // Act
        var actionResult = await _mockController.Get();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var model = Assert.IsType<ListExamplesViewModel>(okResult.Value);

        Assert.Equal(2, model.Examples.Count());
        Assert.Equal(10, model.PageSize);
        Assert.Null(model.NextCursor);
    }
}