using SimpleObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Mappers
{
    public class DemoMapper : IMapper<SampleDTO, SampleDomainClass>
    {
        public SampleDomainClass Map(SampleDTO mapFrom, SampleDomainClass mapTo)
        {
            mapTo.IdMapped = mapFrom.Id;

            return mapTo;
        }
    }

    public class SampleDTO
    {
        public string Id { get; set; }
    }

    public class SampleDomainClass
    {
        public string IdMapped { get; set; }
    }
}
