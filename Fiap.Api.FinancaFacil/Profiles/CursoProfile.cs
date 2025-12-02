using AutoMapper;
using Fiap.Api.FinancaFacil.Models;
using Fiap.Api.FinancaFacil.ViewModel;

namespace Fiap.Api.FinancaFacil.Profiles;

public class CursoProfile : Profile
{
    public CursoProfile()
    {
        CreateMap<CursoModel, CursoViewModel>();
        CreateMap<InputCursoViewModel, CursoModel>();
    }
}