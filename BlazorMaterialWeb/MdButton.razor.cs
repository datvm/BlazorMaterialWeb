namespace BlazorMaterialWeb;

/// <summary>
/// Common buttons prompt most actions in a UI
/// <a href="https://m3.material.io/components/buttons/overview">Design</a>,
/// <a href="https://material-web.dev/components/button/#types">Component</a>
/// </summary>
partial class MdButton
{

    public const string IconSlot = "icon";

    [Parameter]
    public MdButtonType ButtonType { get; set; } = MdButtonType.Elevated;

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public string? Href { get; set; }

    [Parameter]
    public string? Target { get; set; }

    [Parameter]
    public bool TrailingIcon { get; set; }

    [Parameter]
    public bool HasIcon { get; set; }

    [Parameter]
    public FormSubmitterType Type { get; set; } = FormSubmitterType.Submit;

    [Parameter]
    public string? Value { get; set; }

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

/// <summary>
/// From button folder. This is Blazor Material Web merging the components.
/// </summary>
public enum MdButtonType
{
    Elevated,
    Filled,
    Tonal,
    Outlined,
    Text,
}

/// <summary>
/// From form-submitter.ts
/// </summary>
public enum FormSubmitterType
{
    Button,
    Submit,
    Reset,
}