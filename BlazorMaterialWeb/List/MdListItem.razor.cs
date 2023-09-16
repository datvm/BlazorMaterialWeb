namespace BlazorMaterialWeb;

partial class MdListItem
{

    public const string StartSlot = "start";
    public const string StartIconSlot = "start-icon";
    public const string StartImageSlot = "start-image";
    public const string StartAvatarSlot = "start-avatar";
    public const string StartVideoSlot = "start-video";
    public const string StartVideoLargeSlot = "start-video-large";

    public const string EndSlot = "end";
    public const string EndIconSlot = "end-icon";


    [Parameter]
    public bool NonInteractive { get; set; }

    [Parameter]
    public string? Headline { get; set; }

    [Parameter]
    public string? SupportingText { get; set; }

    [Parameter]
    public bool MultilineSupportingText { get; set; }

    [Parameter]
    public bool TrailingSupportingText { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public int? ItemTabIndex { get; set; }

    [Parameter]
    public bool Active { get; set; }

    [Parameter]
    public virtual MdListItemRole Type { get; set; } = MdListItemRole.ListItem;

    [Parameter]
    public string? Href { get; set; }

    [Parameter]
    public string? Target { get; set; }

    protected virtual string TagName => "md-list-item";

}

/// <summary>
/// From list-item.ts
/// </summary>
public enum MdListItemRole
{
    ListItem,
    MenuItem,
    Option,
    Link,
    None
}