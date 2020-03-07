using FluentAssertions;
using Xunit;

using System.Collections.Generic;
using System.Linq;

namespace SimpleObjectMapper.Test
{
    public class ChildPropertyMapperTest
    {
        [Fact]
        public void Mapp_complex_child()
        {
            var source = new SourceMapWithComplexChield { Id = 1, Child = new SourceChield { Name = "1Child" } };

            IMapper<SourceMapWithComplexChield, DestMapWithComplexChield> mapper = new MapperWithComplexChild();

            var result = mapper.Map(source);

            result.IdMapped.Should().Be(source.Id);
            result.ChildMapped.NameMapped.Should().Be(source.Child.Name);
        }

        [Fact]
        public void Mapped_Complex_chile_when_null()
        {
            var source = new SourceMapWithComplexChield { Id = 1 };

            IMapper<SourceMapWithComplexChield, DestMapWithComplexChield> mapper = new MapperWithComplexChild();

            var result = mapper.Map(source);

            result.IdMapped.Should().Be(source.Id);
            result.ChildMapped.Should().BeNull();
        }

        [Fact]
        public void Mapped_Complex_chile_with_child_mapper_when_null()
        {
            var source = new SourceMapWithComplexChield { Id = 1 };

            IMapper<SourceMapWithComplexChield, DestMapWithComplexChield> mapper = new MapperWithComplexChildWithChildMapper();

            var result = mapper.Map(source);

            result.IdMapped.Should().Be(source.Id);
            result.ChildMapped.Should().BeNull();
        }

        [Fact]
        public void Complex_child_collection_wtith_manual_map()
        {
            var source = new SourceMapWithComplexChield
            {
                Id = 1,
                ChildList = new List<SourceChield>
                {
                    new SourceChield{Name="1SourceChild"},
                    new SourceChield{Name="2SourceChild"},
                }
            };
            IMapper<SourceMapWithComplexChield, DestMapWithComplexChield> mapper = new MapperWithComplexChild();

            var result = mapper.Map(source);

            result.ChildListMap.Should().HaveCount(source.ChildList.Count);
            //result.ChildListMap.Join<DestChield, SourceChield, string,>(source, x => x.NameMapped, xx => xx.Name, x => new DestChield { NameMapped = x.NameMapped });
        }

        [Fact]
        public void Complex_child_collection_wtith_child_object_map()
        {
            var source = new SourceMapWithComplexChield
            {
                Id = 1,
                ChildList = new List<SourceChield>
                {
                    new SourceChield{Name="1SourceChild"},
                    new SourceChield{Name="2SourceChild"},
                }
            };
            IMapper<SourceMapWithComplexChield, DestMapWithComplexChield> mapper = new MapperWithComplexChildWithChildMapper();

            var result = mapper.Map(source);

            result.ChildListMap.Should().HaveCount(source.ChildList.Count);
            //result.ChildListMap.Join<DestChield, SourceChield, string,>(source, x => x.NameMapped, xx => xx.Name, x => new DestChield { NameMapped = x.NameMapped });
        }
    }

    public class MapperWithComplexChild : IMapper<SourceMapWithComplexChield, DestMapWithComplexChield>
    {
        public DestMapWithComplexChield Map(SourceMapWithComplexChield mapFrom, DestMapWithComplexChield mapTo)
        {
            mapTo.IdMapped = mapFrom.Id;
            mapTo.ChildMapped = mapFrom.Child == null ? null : new DestChield
            {
                NameMapped = mapFrom.Child?.Name
            };

            mapTo.ChildListMap = mapFrom.ChildList == null ? null : mapFrom.ChildList
                                                                            .Select(x => new DestChield { NameMapped = x.Name })
                                                                            .ToList();

            return mapTo;
        }
    }

    public class MapperWithComplexChildWithChildMapper : IMapper<SourceMapWithComplexChield, DestMapWithComplexChield>
    {
        private readonly IMapper<SourceChield, DestChield> _childMapper = new ChildMapper();

        public DestMapWithComplexChield Map(SourceMapWithComplexChield mapFrom, DestMapWithComplexChield mapTo)
        {
            mapTo.IdMapped = mapFrom.Id;
            mapTo.ChildMapped = _childMapper.Map(mapFrom.Child);
            mapTo.ChildListMap = _childMapper.Map(mapFrom.ChildList);

            return mapTo;
        }
    }

    public class ChildMapper : IMapper<SourceChield, DestChield>
    {
        public DestChield Map(SourceChield mapFrom, DestChield mapTo)
        {
            mapTo.NameMapped = mapFrom.Name;
            return mapTo;
        }
    }

    public class SourceMapWithComplexChield
    {
        public int Id { get; set; }
        public SourceChield Child { get; set; }
        public List<SourceChield> ChildList { get; set; }
    }

    public class DestMapWithComplexChield
    {
        public int IdMapped { get; set; }
        public DestChield ChildMapped { get; set; }
        public IEnumerable<DestChield> ChildListMap { get; set; }
    }

    public class SourceChield
    {
        public string Name { get; set; }
    }

    public class DestChield
    {
        public string NameMapped { get; set; }
    }

}
