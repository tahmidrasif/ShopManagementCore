using AutoMapper;
using BLL.Request.Sale;
using DLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ViewModel.AutoMapper
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<OrderDetailsRequest, OrderDetails>()
                .ForMember(dest=>dest.TotalVat,opt=>opt.MapFrom(src=>src.Vat))
                .ForMember(dest => dest.TotalDiscount, opt => opt.MapFrom(src => src.Discount)).ReverseMap();
        }
    }
}
