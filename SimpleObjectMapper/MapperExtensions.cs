using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleObjectMapper
{
    public static partial class MapperExtensions
    {
        public static TMapTo? Map<TMapFrom, TMapTo>(this IMapper<TMapFrom, TMapTo> mapper,
                                                   TMapFrom mapFrom)
            where TMapTo : class
            where TMapFrom : class
        {
            //_ = mapFrom ?? throw new ArgumentNullException(nameof(mapFrom));
            if (mapFrom == null)
                return default;

            var mapTo = FactoryHelper<TMapTo>.Instance;

            return mapper.Map(mapFrom, mapTo);
        }

        public static IEnumerable<TMapTo?>? Map<TMapFrom, TMapTo>(
            this IMapper<TMapFrom, TMapTo> mapper,
            IEnumerable<TMapFrom> mapFromCollection)
            where TMapTo : class
            where TMapFrom : class

        {
            //_ = mapFromCollection ?? throw new ArgumentNullException(nameof(mapFromCollection));
            _ = mapper ?? throw new ArgumentNullException(nameof(mapper));

            var result = mapFromCollection?.Select(fromElement => mapper.Map(fromElement));

            return result;
        }
    }
}
