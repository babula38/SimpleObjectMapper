using System;

namespace CustomAutomapper
{
    public interface IMapper<TMapFrom, TMapTo>
    {
        TMapTo Map(TMapFrom mapFrom, TMapTo mapTo);
    }
    //public interface IMapper
    //{
    //    TMapTo Map<TMapFrom, TMapTo>(TMapFrom mapFrom, TMapTo mapTo);
    //}

    //public class TestClass : IMapper
    //{
    //    public SampleMapTo Map<SampleMapFrom, SampleMapTo>(SampleMapFrom mapFrom, SampleMapTo mapTo)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //public class TestClass2 : IMapper
    //{
    //    public SampleMapTo2 Map<SampleMapFrom2, SampleMapTo2>(SampleMapFrom2 mapFrom, SampleMapTo2 mapTo)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //public class SampleMapFrom
    //{
    //    public int ID { get; set; }

    //    public string Name { get; set; }
    //}
    //public class SampleMapTo
    //{
    //    public int MapedID { get; set; }

    //    public string MapedName { get; set; }
    //}
    //public class SampleMapFrom2
    //{
    //    public int ID { get; set; }

    //    public string Name { get; set; }
    //}
    //public class SampleMapTo2
    //{
    //    public int MapedID { get; set; }

    //    public string MapedName { get; set; }
    //}
}
