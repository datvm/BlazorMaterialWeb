namespace BlazorMaterialWeb;

/// <summary>
/// Assist chips are common actions, such as adding an event to a calendar.
/// <a href="https://m3.material.io/components/chips/overview">Design</a>,
/// <a href="https://material-web.dev/components/chip/">Component</a>
/// </summary>
public class MdAssistChip : BaseMdChip
{

    [Parameter]
    public bool Elevated { get; set; }

    [Parameter]
    public string? Href { get; set; }

    [Parameter]
    public string? Target { get; set; }

    protected override string TagName => "md-assist-chip";

    protected override IEnumerable<KeyValuePair<string, object?>>? ProtectedAdditionalAttributes =>
        new KeyValuePair<string, object?>[]
        {
            new("elevated", Elevated),
            new("href", Href),
            new("target", Target),
        };

}
