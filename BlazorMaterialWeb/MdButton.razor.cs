namespace BlazorMaterialWeb;

partial class MdButton
{

    [Parameter]
    public MdButtonType ButtonType { get; set; } = MdButtonType.Elevated;

    string ButtonTagName => ButtonType switch
    {
        MdButtonType.Elevated => "md-elevated-button",
        MdButtonType.Filled => "md-filled-button",
        MdButtonType.Tonal => "md-filled-tonal-button",
        MdButtonType.Outlined => "md-outlined-button",
        MdButtonType.Text => "md-text-button",
        _ => throw new NotImplementedException(ButtonType.ToString()),
    };

}

public enum MdButtonType
{
    Elevated,
    Filled,
    Tonal,
    Outlined,
    Text,
}