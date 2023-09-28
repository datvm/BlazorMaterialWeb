namespace BlazorMaterialWeb;

partial class MdMenuItem
{
    public const string HeadlineSlot = "headline";
    public const string OverlineSlot = "overline";
    public const string SupportingTextSlot = "supporting-text";
    public const string TrailingSupportingTextSlot = "trailing-supporting-text";

    public const string StartSlot = "start";
    public const string EndSlot = "end";

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public MdMenuItemType? Type { get; set; }

    [Parameter]
    public string? Href { get; set; }

    [Parameter]
    public string? Target { get; set; }

    [Parameter]
    public bool KeepOpen { get; set; }

    [Parameter]
    public bool Selected { get; set; }

    [Parameter]
    public string? TypeaheadText { get; set; }

}

/// <summary>
/// From menuItemController.ts
/// </summary>
public enum MdMenuItemType
{
    MenuItem,
    Option,
    Button,
    Link,
}