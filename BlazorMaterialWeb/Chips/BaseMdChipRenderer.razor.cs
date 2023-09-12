namespace BlazorMaterialWeb.Chips;

partial class BaseMdChipRenderer
{

    [Parameter, EditorRequired]
    public ChipType Type { get; set; }

    [Parameter, EditorRequired]
    public bool Elevated { get; set; }

    [Parameter, EditorRequired]
    public string? Label { get; set; }

    [Parameter, EditorRequired]
    public bool Disabled { get; set; }

    string TagName => GetTagName(Type);

    public static string GetTagName(ChipType type) => type switch
    {
        ChipType.Assist => "md-assist-chip",
        ChipType.Suggestion => "md-suggestion-chip",
        ChipType.Filter => "md-filter-chip",
        ChipType.Input => "md-input-chip",
        _ => throw new NotImplementedException("Unknown chip type: " + type),
    };

}