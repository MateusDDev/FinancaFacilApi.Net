using AutoMapper;
using Fiap.Api.FinancaFacil.Models;
using Fiap.Api.FinancaFacil.ViewModel;

namespace Fiap.Api.FinancaFacil.Profiles;

public class DespesaProfile : Profile
{
    public DespesaProfile()
    {
        CreateMap<DespesaModel, DespesaViewModel>();
        CreateMap<InputDespesaViewModel, DespesaModel>();
    }
}