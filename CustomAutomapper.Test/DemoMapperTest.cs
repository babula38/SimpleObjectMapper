using System;
using Xunit;
using FluentAssertions;

namespace CustomAutomapper.Test
{
    public class DemoMapperTest
    {
        [Fact]
        public void Mapper_should_map_the_values_correctly()
        {
            var mapFrom = new SampleMapFrom { ID = 1, Name = "Test Name" };
            var mapTo = new SampleMapTo();

            var mapedResult = new DemoMapper().Map(mapFrom, mapTo);

            mapedResult.MapedID.Should().Be(mapFrom.ID);
            mapedResult.MapedName.Should().Be(mapFrom.Name);
        }
    }

    public class DemoMapper : IMapper<SampleMapFrom, SampleMapTo>
    {
        public SampleMapTo Map(SampleMapFrom mapFrom, SampleMapTo mapTo)
        {
            mapTo.MapedID = mapFrom.ID;
            mapTo.MapedName = mapFrom.Name;

            return mapTo;
        }

        public SampleMapTo Map(SampleMapFrom mapFrom)
        {
            _ = mapFrom ?? throw new ArgumentNullException(nameof(mapFrom));

            var mapTo = new SampleMapTo()
            {

            };

            return mapTo;
        }
    }

    public class SampleMapFrom
    {
        public int ID { get; set; }

        public string Name { get; set; }
    }
    public class SampleMapTo
    {
        public int MapedID { get; set; }

        public string MapedName { get; set; }
    }
}
