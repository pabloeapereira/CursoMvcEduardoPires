using AutoMapper;
using EP.CursoMvc.Application.ViewModels;
using EP.CursoMvc.Domain.Models;

namespace EP.CursoMvc.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile:Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteEnderecoViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Endereco,ClienteEnderecoViewModel>().ReverseMap();
        }
    }
}
