namespace WrappArr.Classes.Series
{
    public class Season
    {
        public int SeasonNumber { get; set; }
        public bool Monitored { get; set; }
        public Statistics Statistics { get; set; }
        public List<Image> Images { get; set; }
    }
}