using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Mappers;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IMapper<SampleDTO, SampleDomainClass> _mapper;

        public HomeController(IMapper<SampleDTO, SampleDomainClass> mapper)
        {
            _mapper = mapper;
        }
        [HttpGet]
        public void Get()
        {
            var dto = new SampleDTO { Id = "1" };
            var business = _mapper.Map(dto);
        }
    }
}
