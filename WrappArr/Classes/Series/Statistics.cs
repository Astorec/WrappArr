namespace WrappArr.Classes.Series
{
    public class Statistics
    {
        public int SeasonCount { get; set; }
        public int EpisodeFileCount { get; set; }
        public int EpisodeCount { get; set; }
        public int TotalEpisodeCount { get; set; }
        public long SizeOnDisk { get; set; }
        public List<string> ReleaseGroups { get; set; }
        public int PercentOfEpisodes { get; set; }
    }
}