using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.BusinessLogic.DTO.Category;
using WebStore.Domain.Entities;

namespace WebStore.BusinessLogic.Mapping
{
    public class CategoryProfile
        : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryForDropDownList>();
                //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
