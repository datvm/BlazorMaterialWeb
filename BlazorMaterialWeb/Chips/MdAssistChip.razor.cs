namespace BlazorMaterialWeb;

partial class MdAssistChip
{

    // For Suggestion Chip support
    protected virtual MdChipType Type => MdChipType.Assist;

    [Parameter]
    public string? Href { get; set; }

    [Parameter]
    public string? Target { get; set; }

}