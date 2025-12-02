using AutoMapper;
using Fiap.Api.FinancaFacil.Controllers;
using Fiap.Api.FinancaFacil.Models;
using Fiap.Api.FinancaFacil.Services;
using Fiap.Api.FinancaFacil.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Fiap.Api.FinancaFacil.Tests;

public sealed class UsuarioControllerTests
{
    private readonly Mock<IUsuarioService> _mockService;
    private readonly Mock<IMapper> _mockMapper;
    private readonly UsuarioController _mockController;

    public UsuarioControllerTests()
    {
        _mockMapper = new Mock<IMapper>();
        _mockService = new Mock<IUsuarioService>();
        _mockController = new UsuarioController(_mockService.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task Get_ReturnsOkResult_WithListUsuariosViewModel()
    {
        // Arrange
        var serviceExamples = new List<UsuarioModel>
        {
            new()
            {
                IdUsuario = 1, 
                NmUsuario = "Cliente 1", 
                Senha = "123", 
                Celular = "999999999", 
                Cpf = "000.000.000-00",
                DtNascimento = new DateTime(1990, 1, 1)
            },
            new()
            {
                IdUsuario = 2, 
                NmUsuario = "Cliente 2", 
                Senha = "173", 
                Celular = "999991999", 
                Cpf = "020.100.000-00",
                DtNascimento = new DateTime(2010, 2, 10)
            },
        };

        _mockService.Setup(s => s.GetUsuarios(0, 10))
            .ReturnsAsync(serviceExamples);

        _mockMapper.Setup(m => m.Map<IList<UsuarioViewModel>>(It.IsAny<IList<UsuarioModel>>()))
            .Returns(serviceExamples.Select(_ => new UsuarioViewModel {
                IdUsuario = 1, 
                NmUsuario = "Cliente 1", 
                Senha = "123", 
                Celular = "999999999", 
                Cpf = "000.000.000-00",
                DtNascimento = new DateTime(1990, 1, 1)
            }).ToList());

        // Act
        var actionResult = await _mockController.List();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var model = Assert.IsType<ListUsuariosViewModel>(okResult.Value);

        Assert.Equal(2, model.Usuarios.Count());
        Assert.Equal(10, model.PageSize);
        Assert.Null(model.NextCursor);
    }
}