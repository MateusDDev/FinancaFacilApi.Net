using AutoMapper;
using Fiap.Api.FinancaFacil.Models;
using Fiap.Api.FinancaFacil.ViewModel;

namespace Fiap.Api.FinancaFacil.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<UsuarioModel, UsuarioViewModel>();
        CreateMap<InputUsuarioViewModel, UsuarioModel>();
    }
}