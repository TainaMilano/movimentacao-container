using Application.Models;
using AutoMapper;

namespace Application.ViewModel
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MovimentacaoRequest, Movimentacao>();
        }
    }
}
