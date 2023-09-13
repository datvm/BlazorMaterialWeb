namespace BlazorMaterialWeb;

/// <summary>
/// Dividers are thin lines that group content in lists or other containers.
/// <a href="https://m3.material.io/components/divider/overview">Design</a>,
/// <a href="https://github.com/material-components/material-web/blob/main/docs/components/divider.md">Reference</a>.
/// </summary>
partial class MdDivider
{

    [Parameter]
    public bool Inset { get; set; }

    [Parameter]
    public bool InsetStart { get; set; }

    [Parameter]
    public bool InsetEnd { get; set; }

}
