namespace WrappArr.Classes.Calendar
{
    public class Calendar
    {
    public int SeriesId { get; set; }
    public int TvdbId { get; set; }
    public int EpisodeFileId { get; set; }
    public int SeasonNumber { get; set; }
    public int EpisodeNumber { get; set; }
    public string Title { get; set; }
    public string AirDate { get; set; }
    public DateTime AirDateUtc { get; set; }
    public int Runtime { get; set; }
    public string Overview { get; set; }
    public bool HasFile { get; set; }
    public bool Monitored { get; set; }
    public bool UnverifiedSceneNumbering { get; set; }
    public Series Series { get; set; }
    public List<Image> Images { get; set; }
    public bool Grabbed { get; set; }
    public int Id { get; set; }
    }
}
