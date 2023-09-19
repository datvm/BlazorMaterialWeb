namespace BlazorMaterialWeb.Chips;

partial class BaseMdChipRenderer
{

    [Parameter, EditorRequired]
    public MdChipType Type { get; set; }

    [Parameter, EditorRequired]
    public bool Elevated { get; set; }

    [Parameter, EditorRequired]
    public string? Label { get; set; }

    [Parameter, EditorRequired]
    public bool Disabled { get; set; }

    string TagName => GetTagName(Type);

    public static string GetTagName(MdChipType type) => type switch
    {
        MdChipType.Assist => "md-assist-chip",
        MdChipType.Suggestion => "md-suggestion-chip",
        MdChipType.Filter => "md-filter-chip",
        MdChipType.Input => "md-input-chip",
        _ => throw new NotImplementedException("Unknown chip type: " + type),
    };

}