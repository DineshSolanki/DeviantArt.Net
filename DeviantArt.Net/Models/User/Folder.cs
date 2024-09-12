using DeviantArt.Net.Models.Deviation;

namespace DeviantArt.Net.Models.User;

public class Folder
{
    [JsonPropertyName("folderid")]
    public Guid FolderId { get; set; }

    [JsonPropertyName("parent")]
    public Guid? Parent { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("size")]
    public int? Size { get; set; }

    [JsonPropertyName("thumb")]
    public Deviation.Deviation? Thumb { get; set; }
}

public class GalleryFolder : Folder
{
    [JsonPropertyName("parent")]
    public Guid? Parent { get; set; }

    [JsonPropertyName("premium_folder_data")]
    public PremiumFolderData? PremiumFolderData { get; set; }

    [JsonPropertyName("has_subfolders")]
    public bool? HasSubfolders { get; set; }

    [JsonPropertyName("subfolders")]
    public List<GalleryFolder>? Subfolders { get; set; }

    [JsonPropertyName("deviations")]
    public List<Deviation.Deviation>? Deviations { get; set; }
}

public class CollectionFolder : Folder
{
    [JsonPropertyName("deviations")]
    public List<Deviation.Deviation>? Deviations { get; set; }
}