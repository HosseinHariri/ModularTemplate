using AutoMapper;
using ModularTemplate.Application.Customers.Create;
using ModularTemplate.Application.Customers.GetList;
using ModularTemplate.Presentation.Server.Common;
using ModularTemplate.Presentation.Server.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ModularTemplate.Presentation.Server.Controllers.Customers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : BaseController
    {
        private readonly IMapper mapper;
        private readonly ICreateCustomerHandler createCustomerHandler;
        private readonly IGetCustomersHandler getCustomersHandler;

        public CustomerController(IMapper mapper,
                                  ICreateCustomerHandler createCustomerHandler,
                                  IGetCustomersHandler getCustomersHandler)
        {
            this.mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
            this.createCustomerHandler = createCustomerHandler ?? throw new System.ArgumentNullException(nameof(createCustomerHandler));
            this.getCustomersHandler = getCustomersHandler ?? throw new System.ArgumentNullException(nameof(getCustomersHandler));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CustomerRequest request)
        {
            var param = mapper.Map<CreateCustomerParam>(request);

            var response = createCustomerHandler.Handle(param);

            return ResponseFrom(response);
        }

        [HttpPut("{id}")]
        public IActionResult Edit([FromRoute] int id,
                                  [FromBody] CustomerRequest request)
        {
            return View();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            return View();
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            return View();
        }

        [HttpGet("list")]
        public IActionResult GetList()
        {
            var response = getCustomersHandler.Handle();

            return ResponseFrom(response);
        }
    }
}