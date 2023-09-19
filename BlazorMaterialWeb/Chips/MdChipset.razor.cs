namespace BlazorMaterialWeb;

/// <summary>
/// Chips should always appear in a set. Use the same type of chip for chip set children.
/// <a href="https://m3.material.io/components/chips/overview">Design</a>,
/// <a href="https://material-web.dev/components/chip/">Component</a>
/// </summary>
partial class MdChipset
{

    [Parameter, EditorRequired]
    public MdChipType Type { get; set; } = MdChipType.Suggestion;

    [Parameter]
    public bool SingleSelect { get; set; } 

}

/// <summary>
/// From: <a href="https://github.com/material-components/material-web/blob/c26a578448666fda50eb2b25be59b88390e32097/chips/internal/chip-set.ts#L18">chip-set.ts</a>
/// </summary>
public enum MdChipType
{
    Assist,
    Suggestion,
    Filter,
    Input
}