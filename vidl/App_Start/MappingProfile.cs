using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidl.Dtos;
using vidl.Models;

namespace vidl.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer,CustomerDto>();
            Mapper.CreateMap<CustomerDto,Customer>();
            Mapper.CreateMap<MovieDto, Movie>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();



        }
    }
}