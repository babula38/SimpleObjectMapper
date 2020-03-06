namespace CustomAutomapper.Test
{
    public class DemoMapper : IMapper<SampleMapFrom, SampleMapTo>
    {
        public SampleMapTo Map(SampleMapFrom mapFrom, SampleMapTo mapTo)
        {
            mapTo.MapedID = mapFrom.Id;
            mapTo.MapedName = mapFrom.Name;

            return mapTo;
        }
    }
}
