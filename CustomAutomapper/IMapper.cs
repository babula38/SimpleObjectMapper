using System;

namespace CustomAutomapper
{
    public interface IMapper<TMapFrom, TMapTo>
    {
        TMapTo Map(TMapFrom mapFrom, TMapTo mapTo);
    }
}
