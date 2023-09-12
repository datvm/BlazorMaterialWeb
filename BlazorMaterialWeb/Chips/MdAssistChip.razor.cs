namespace BlazorMaterialWeb;

partial class MdAssistChip
{

    // For Suggestion Chip support
    protected virtual ChipType Type => ChipType.Assist;

    [Parameter]
    public string? Href { get; set; }

    [Parameter]
    public string? Target { get; set; }

}