namespace DeviantArt.Net.Models.Deviation;

public class DeviationDownloadMetadata
{
    /// <summary>
    /// The URL to download the deviation, the file type could be anything from those allowed by DeviantArt <see href="https://www.deviantartsupport.com/kb/en/article/what-file-types-can-i-submit-to-deviantart"/>
    /// </summary>
    [JsonPropertyName("src")]
    public string Src { get; init; }

    /// <summary>
    ///  The filename of the deviation
    /// </summary>
    [JsonPropertyName("filename")]
    public string Filename { get; init; }

    /// <summary>
    ///  The width of the deviation
    /// </summary>
    [JsonPropertyName("width")]
    public int Width { get; init; }

    /// <summary>
    ///  The height of the deviation
    /// </summary>
    [JsonPropertyName("height")]
    public int Height { get; init; }

    /// <summary>
    ///  The filesize of the deviation in bytes
    /// </summary>
    [JsonPropertyName("filesize")]
    public int FileSizeBytes { get; init; }
}