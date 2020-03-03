using Xunit;
using FluentAssertions;

namespace CustomAutomapper.Test
{
    public class DemoMapperTest
    {
        [Fact]
        public void Mapper_should_map_the_values_correctly()
        {
            //Expression<Action> x = () => new DemoMapperTest();
            //NewExpression s = (NewExpression)x.Body;

            var mapFrom = new SampleMapFrom { Id = 1, Name = "Test Name" };
            var mapTo = new SampleMapTo();

            var mapedResult = new DemoMapper().Map(mapFrom, mapTo);

            mapedResult.MapedID.Should().Be(mapFrom.Id);
            mapedResult.MapedName.Should().Be(mapFrom.Name);
        }

        [Fact]
        public void Mapper_should_work_without_supplying_mapto_object()
        {
            var mapFrom = new SampleMapFrom { Id = 1, Name = "Name" };

            IMapper<SampleMapFrom, SampleMapTo> mapper = new DemoMapper();

            var mapResult = mapper.Map(mapFrom);

            mapResult.Should().NotBeNull();
            mapResult.MapedName.Should().Be(mapFrom.Name);
            mapResult.MapedID.Should().Be(mapFrom.Id);
        }

        [Fact]
        public void Should_work_with_array()
        {
            var mapFromArray = new SampleMapFrom[] {
                new SampleMapFrom{Id=1,Name="Name1"},
                new SampleMapFrom{Id=2,Name="Name2"},
            };

            IMapper<SampleMapFrom, SampleMapTo> mapper = new DemoMapper();

            var mapResult = mapper.Map(mapFromArray);
        }
    }



    public class DemoMapper : IMapper<SampleMapFrom, SampleMapTo>
    {
        public SampleMapTo Map(SampleMapFrom mapFrom, SampleMapTo mapTo)
        {
            mapTo.MapedID = mapFrom.Id;
            mapTo.MapedName = mapFrom.Name;

            return mapTo;
        }
    }

    public class SampleMapFrom
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class SampleMapTo
    {
        public int MapedID { get; set; }
        public string MapedName { get; set; }
    }
}
