using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using PatintIS.Application.Features.Commands.CreatePatint;
using PatintIS.Application.Features.Commands.DeletePatint;
using PatintIS.Application.Features.Commands.UpdatePatint;
using PatintIS.Application.Features.Queries.GetPatintDetail;
using PatintIS.Application.Features.Queries.GetPatintList;
using PatintIS.Domain;

namespace PatintIS.Application.Profiles
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Patint, CreatePatintCommand>().ReverseMap();
            CreateMap<Patint, DeletePatintCommand>().ReverseMap();
            CreateMap<Patint, UpdatePatintCommand>().ReverseMap();
            CreateMap<Patint, GetPatintsListViewModel>().ReverseMap();
            CreateMap<Patint, GetPatintDetailViewModel>().ReverseMap();
        } 
    }
}
