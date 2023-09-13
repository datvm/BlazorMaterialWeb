namespace BlazorMaterialWeb;

/// <summary>
/// Focus rings are accessible outlines for components to show keyboard focus.
/// <a href="https://github.com/material-components/material-web/blob/main/docs/components/focus-ring.md">Documentation</a>
/// </summary>
partial class MdFocusRing
{

    [Parameter]
    public bool Visible { get; set; }

    [Parameter]
    public bool Inward { get; set; }

}
