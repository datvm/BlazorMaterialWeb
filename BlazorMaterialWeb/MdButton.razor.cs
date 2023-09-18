namespace BlazorMaterialWeb;

/// <summary>
/// Common buttons prompt most actions in a UI
/// <a href="https://m3.material.io/components/buttons/overview">Design</a>,
/// <a href="https://material-web.dev/components/button/">Component</a>
/// </summary>
partial class MdButton
{

    public const string IconSlot = "icon";

    [Parameter]
    public MdButtonStype Style { get; set; } = MdButtonStype.Elevated;

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

    string ButtonTagName => Style switch
    {
        MdButtonStype.Elevated => "md-elevated-button",
        MdButtonStype.Filled => "md-filled-button",
        MdButtonStype.Tonal => "md-filled-tonal-button",
        MdButtonStype.Outlined => "md-outlined-button",
        MdButtonStype.Text => "md-text-button",
        _ => throw new NotImplementedException(Style.ToString()),
    };

}

/// <summary>
/// From button folder. This is Blazor Material Web merging the components.
/// </summary>
public enum MdButtonStype
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