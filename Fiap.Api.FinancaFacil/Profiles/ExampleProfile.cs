using AutoMapper;
using Fiap.Api.FinancaFacil.Models;
using Fiap.Api.FinancaFacil.ViewModel;

namespace Fiap.Api.FinancaFacil.Profiles;

public class ExampleProfile : Profile
{
    public ExampleProfile()
    {
        CreateMap<ExampleModel, ExampleViewModel>();
        CreateMap<InputExampleViewModel, ExampleModel>();
    }
}