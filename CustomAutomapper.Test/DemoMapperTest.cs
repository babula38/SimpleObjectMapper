using CustomAutomapper.Test;
using FluentAssertions;
using SimpleObjectMapper;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SimpleObjectMapper.Test
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

            var mappedResult = mapper.Map(mapFromArray);
            mappedResult.Should().NotBeEmpty()
                    .And.HaveCount(mapFromArray.Count());
            //TODO: Need to check how to comapre 2 different type collection in fluent assertation
        }

        [Fact]
        public void Mapp_List_element()
        {
            var mapList = new List<SampleMapFrom>
            {
                new SampleMapFrom{Id=1,Name="1Name"},
                new SampleMapFrom{Id=2,Name="2Name"}
            };
            IMapper<SampleMapFrom, SampleMapTo> mapper = new DemoMapper();

            var mappedResult = mapper.Map(mapList);

            mappedResult.Should().NotBeEmpty()
                    .And.HaveCount(mapList.Count);
        }

    }

}
