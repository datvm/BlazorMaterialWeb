namespace BlazorMaterialWeb;

/// <summary>
/// Floating action buttons (FABs) help people take primary actions.
/// <a href="https://m3.material.io/components/floating-action-button/overview">Design</a>,
/// <a href="https://material-web.dev/components/fab/">Component</a>.
/// </summary>
partial class MdFab
{
    public const string IconSlot = "icon";

    [Parameter]
    public MdFabVariant Variant { get; set; } = MdFabVariant.Surface;

    [Parameter]
    public string Label { get; set; } = "";

    [Parameter]
    public MdFabSize Size { get; set; } = MdFabSize.Medium;

    [Parameter]
    public bool Lowered { get; set; }

    [Parameter]
    public bool Branded { get; set; }

    string TagName => Branded ? "md-branded-fab" : "md-fab";

}

/// <summary>
/// From <a href="https://github.com/material-components/material-web/blob/fe79d2adfd7c8f92c1f9efdf5a4e5b1358878934/fab/internal/fab.ts#L14">fab/internal/fab.ts</a>
/// </summary>
public enum MdFabVariant
{
    Surface,
    Primary,
    Secondary,
    Tertiary,
}

/// <summary>
/// From <a href="https://github.com/material-components/material-web/blob/fe79d2adfd7c8f92c1f9efdf5a4e5b1358878934/fab/internal/shared.ts#L21">fab/internal/shared.ts</a>
/// </summary>
public enum MdFabSize
{
    Medium,
    Small,
    Large,
}