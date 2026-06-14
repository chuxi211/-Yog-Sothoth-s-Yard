using System.Collections.Generic;
using System.Linq;

public class ForestExploreRunning
{
    public ExploreRegion ExploreRegion { get; private set; }
    public int ConsumeTimePeriod { get;set; }
    public List<DropEntry > candidate { get; private set; }
    public ForestExploreRunning(ForestExploreConfigInfo config)
    {
        ExploreRegion = config.ExploreRegion;
        ConsumeTimePeriod = config.ConsumeTimePeriod;
        candidate = config.ExploreDropConfigTable.dropEntries;
    }
}
