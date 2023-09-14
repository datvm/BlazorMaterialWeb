namespace BlazorMaterialWeb;

partial class MdListItem
{

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
    public MdListItemRole Type { get; set; } = MdListItemRole.ListItem;

    [Parameter]
    public string? Href { get; set; }

    [Parameter]
    public string? Target { get; set; }

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