using ModularTemplate.Framework;
using System.Collections.Generic;

namespace ModularTemplate.Application.Customers.GetList
{
    public interface IGetCustomersHandler : IHandlerWithResponse<ICollection<GetCustomersVm>>
    {
    }
}