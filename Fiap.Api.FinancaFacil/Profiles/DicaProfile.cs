using AutoMapper;
using Fiap.Api.FinancaFacil.Models;
using Fiap.Api.FinancaFacil.ViewModel;

public class DicaProfile : Profile
{
    public DicaProfile()
    {
        CreateMap<DicaModel, DicaViewModel>();
    }
}