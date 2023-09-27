namespace BlazorMaterialWeb;

/// <summary>
/// Lists are continuous, vertical indexes of text and images.
/// <a href="https://m3.material.io/components/lists/overview">Design</a>,
/// <a href="https://material-web.dev/components/list/">Component</a>
/// </summary>
partial class MdListItem
{

    public const string StartSlot = "start";
    public const string EndSlot = "end";

    public const string OverlineSlot = "overline";
    public const string HeadlineSlot = "headline";
    public const string SupportingText = "supporting-text";
    public const string TrailingSupportingText = "trailing-supporting-text";

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public MdListItemType? Type { get; set; }

    [CascadingParameter(Name = "MdListType")]
    public MdListItemType? CascadedType { get; set; }

    [Parameter]
    public string? Href { get; set; }

    [Parameter]
    public string? Target { get; set; }

    [Parameter]
    public EventCallback OnRequestActivation { get; set; }

    MdListItemType? finalType => Type ?? CascadedType;

}

/// <summary>
/// From list-item.ts
/// </summary>
public enum MdListItemType
{
    Text,
    Button,
    Link,
}