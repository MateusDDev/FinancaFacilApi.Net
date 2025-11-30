using AutoMapper;
using Fiap.Api.FinancaFacil.Models;
using Fiap.Api.FinancaFacil.ViewModel;

namespace Fiap.Api.FinancaFacil.Profiles;

public class RendaProfile : Profile
{
    public RendaProfile()
    {
        CreateMap<RendaModel, RendaViewModel>();
        CreateMap<InputRendaViewModel, RendaModel>();
    }
}