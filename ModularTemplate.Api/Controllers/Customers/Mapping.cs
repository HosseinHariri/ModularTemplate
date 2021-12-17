using AutoMapper;
using ModularTemplate.Application.Customers.Create;
using ModularTemplate.Application.Customers.GetList;
using ModularTemplate.Presentation.Server.Requests;

namespace ModularTemplate.Presentation.Server.Controllers.Customers
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CustomerRequest, CreateCustomerParam>();
        }
    }
}