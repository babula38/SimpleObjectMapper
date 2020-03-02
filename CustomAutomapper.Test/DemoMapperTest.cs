using System;
using Xunit;
using FluentAssertions;
using System.Linq.Expressions;

namespace CustomAutomapper.Test
{
    public class DemoMapperTest
    {
        [Fact]
        public void Mapper_should_map_the_values_correctly()
        {
            //Expression<Action> x = () => new DemoMapperTest();
            //NewExpression s = (NewExpression)x.Body;

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
    }

    public static class MapperExtensions
    {
        public static TMapTo Map<TMapFrom, TMapTo>(this IMapper<TMapFrom, TMapTo> mapper, TMapFrom mapFrom)
            where TMapTo : new()
        {
            _ = mapFrom ?? throw new ArgumentNullException(nameof(mapFrom));

            var mapTo = FactoryHelper<TMapTo>.Instance;

            return mapper.Map(mapFrom, mapTo);
        }
    }

    public static class FactoryHelper<TInstance>
    {
        private static readonly Func<TInstance> createInstanceFunc =
            Expression.Lambda<Func<TInstance>>(Expression.New(typeof(TInstance))).Compile();

        public static TInstance Instance => createInstanceFunc();
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
