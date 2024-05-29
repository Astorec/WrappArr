using WrappArr.Classes.General;

namespace WrappArr.Classes.SeriesLookup
{
    public class Series
    {
        public string Title { get; set; }
        public string SortTitle { get; set; }
        public string Status { get; set; }
        public bool Ended { get; set; }
        public string Overview { get; set; }
        public string Network { get; set; }
        public List<Image> Images { get; set; }
        public Language OriginalLanguage { get; set; }
        public string RemotePoster { get; set; }
        public List<Season> Seasons { get; set; }
        public int Year { get; set; }
        public string Path { get; set; }
        public int QualityProfileId { get; set; }
        public bool SeasonFolder { get; set; }
        public bool Monitored { get; set; }
        public string MonitorNewItems { get; set; }
        public bool UseSceneNumbering { get; set; }
        public int Runtime { get; set; }
        public int TvdbId { get; set; }
        public int TvRageId { get; set; }
        public int TvMazeId { get; set; }
        public DateTime FirstAired { get; set; }
        public DateTime LastAired { get; set; }
        public string SeriesType { get; set; }
        public string CleanTitle { get; set; }
        public string ImdbId { get; set; }
        public string TitleSlug { get; set; }
        public string Folder { get; set; }
        public string Certification { get; set; }
        public List<string> Genres { get; set; }
        public List<object> Tags { get; set; }
        public DateTime Added { get; set; }
        public Ratings Ratings { get; set; }
        public Statistics Statistics { get; set; }
        public int LanguageProfileId { get; set; }
        public int Id { get; set; }
    }
}