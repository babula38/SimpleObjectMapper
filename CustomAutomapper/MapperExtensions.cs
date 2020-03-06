using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomAutomapper
{
    public static partial class MapperExtensions
    {
        public static TMapTo Map<TMapFrom, TMapTo>(this IMapper<TMapFrom, TMapTo> mapper,
                                                   TMapFrom mapFrom)
            where TMapTo : new()
            where TMapFrom : new()
        {
            //_ = mapFrom ?? throw new ArgumentNullException(nameof(mapFrom));
            if (mapFrom == null)
                return default;

            var mapTo = FactoryHelper<TMapTo>.Instance;

            return mapper.Map(mapFrom, mapTo);
        }

        public static IEnumerable<TMapTo> Map<TMapFrom, TMapTo>(
            this IMapper<TMapFrom, TMapTo> mapper,
            IEnumerable<TMapFrom> mapFromCollection)
            where TMapTo : new()
            where TMapFrom : new()

        {
            _ = mapFromCollection ?? throw new ArgumentNullException(nameof(mapFromCollection));
            _ = mapper ?? throw new ArgumentNullException(nameof(mapper));

            var result = mapFromCollection.Select(fromElement => mapper.Map(fromElement));

            return result;
        }
    }
}
