using AutoMapper;
using LivrariaApi.Data.Dtos;
using LivrariaApi.Models;

namespace LivrariaApi.Profiles
{
    public class LivroProfile : Profile
    {
        public LivroProfile()
        {
            CreateMap<CreateLivroDto, Livro>();
            CreateMap<Livro, ReadLivroDto>();
            CreateMap<UpdateLivroDto, Livro>();
        }
    }
}
