namespace DeviantArt.Net.Models.Deviation;

/// <summary>
/// Copy a list of deviations to a folder destination
/// </summary>
public class CopyDeviationsRequest
{
    [AliasAs("target_folderid")]
    public Guid TargetFolderId { get; set; }
    
    [AliasAs("deviationids")]
    [Query(CollectionFormat.Multi)]
    public List<Guid> DeviationIds { get; set; }
}

public class MoveDeviationsRequest : CopyDeviationsRequest
{
    [AliasAs("source_folderid")]
    public Guid SourceFolderId { get; set; }
}