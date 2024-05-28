using System.Text.Json.Serialization;

namespace WrappArr.Classes.Calendar
{
    public class EpisodeFile
    {
        public int Id { get; set; }
        public int SeriesId { get; set; }
        public int SeasonNumber { get; set; }
        public string RelativePath { get; set; }
        public string Path { get; set; }
        public long Size { get; set; }
        public DateTime DateAdded { get; set; }
        public string SceneName { get; set; }
        public string ReleaseGroup { get; set; }
        public List<Language> Languages { get; set; }
        public Quality Quality { get; set; }
        public List<CustomFormat> CustomFormats { get; set; }
        public int CustomFormatScore { get; set; }
        public int IndexerFlags { get; set; }
        public string ReleaseType { get; set; }
        public MediaInfo MediaInfo { get; set; }
        public bool QualityCutoffNotMet { get; set; }
    }

    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Quality
    {
        [JsonPropertyName("quality")]
        public QualityDetail QualityD { get; set; }
        public Revision Revision { get; set; }
    }

    public class QualityDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Source { get; set; }
        public int Resolution { get; set; }
    }

    public class Revision
    {
        public int Version { get; set; }
        public int Real { get; set; }
        public bool IsRepack { get; set; }
    }

    public class CustomFormat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IncludeCustomFormatWhenRenaming { get; set; }
        public List<Specification> Specifications { get; set; }
    }
    public class Specification
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Implementation { get; set; }
        public string ImplementationName { get; set; }
        public string InfoLink { get; set; }
        public bool Negate { get; set; }
        public bool Required { get; set; }
        public List<Field> Fields { get; set; }
        public List<string> Presets { get; set; }
    }

    public class Field
    {
        public int Order { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Unit { get; set; }
        public string HelpText { get; set; }
        public string HelpTextWarning { get; set; }
        public string HelpLink { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public bool Advanced { get; set; }
        public List<SelectOption> SelectOptions { get; set; }
        public string SelectOptionsProviderAction { get; set; }
        public string Section { get; set; }
        public string Hidden { get; set; }
        public string Privacy { get; set; }
        public string Placeholder { get; set; }
        public bool IsFloat { get; set; }
    }

    public class SelectOption
    {
        public int Value { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string Hint { get; set; }
    }

    public class MediaInfo
    {
        public int Id { get; set; }
        public int AudioBitrate { get; set; }
        public int AudioChannels { get; set; }
        public string AudioCodec { get; set; }
        public string AudioLanguages { get; set; }
        public int AudioStreamCount { get; set; }
        public int VideoBitDepth { get; set; }
        public int VideoBitrate { get; set; }
        public string VideoCodec { get; set; }
        public double VideoFps { get; set; }
        public string VideoDynamicRange { get; set; }
        public string VideoDynamicRangeType { get; set; }
        public string Resolution { get; set; }
        public string RunTime { get; set; }
        public string ScanType { get; set; }
        public string Subtitles { get; set; }
    }

}