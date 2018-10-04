﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<Movie, MoviesDto>();
            Mapper.CreateMap<MoviesDto, Movie>().ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<MembershipType, MembershipTypeDto>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<Genre, GenreDto>();
        }
    }
}