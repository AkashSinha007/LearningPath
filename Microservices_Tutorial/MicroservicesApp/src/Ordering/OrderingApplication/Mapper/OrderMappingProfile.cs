using AutoMapper;
using OrderingApplication.Commands;
using OrderingApplication.Responses;
using OrderingCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderingApplication.Mapper
{
    public class OrderMappingProfile:Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderResponse>().ReverseMap();
            CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
        }
    }
}
