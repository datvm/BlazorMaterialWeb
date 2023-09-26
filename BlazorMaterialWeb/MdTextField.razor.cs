namespace BlazorMaterialWeb;

/// <summary>
/// Separated class for the constants so it can be used without specifying generic parameter.
/// </summary>
public class MdTextField
{
    public const string LeadingIconSlot = "leading-icon";
    public const string TrailingIconSlot = "trailing-icon";
}

/// <summary>
/// Text fields let users enter text into a UI.
/// <a href="https://m3.material.io/components/text-fields/overview">Design</a>,
/// <a href="https://github.com/material-components/material-web/blob/main/docs/components/text-field.md">Component</a>
/// </summary>
partial class MdTextField<TValue>
{

    [Parameter]
    public MdTextFieldStyle TextFieldStyle { get; set; } = MdTextFieldStyle.Outlined;

    /// <summary>
    /// This property is a string with MdTextFieldTypes because you can
    /// use custom value for it.
    /// </summary>
    [Parameter]
    public string Type { get; set; } = MdTextFieldTypes.Text;
    [Parameter]
    public bool Disabled { get; set; }
    [Parameter]
    public bool Error { get; set; }
    [Parameter]
    public string? ErrorText { get; set; }
    [Parameter]
    public string? Label { get; set; }
    [Parameter]
    public bool Required { get; set; }
    [Parameter]
    public string? PrefixText { get; set; }
    [Parameter]
    public string? SuffixText { get; set; }
    [Parameter]
    public bool HasLeadingIcon { get; set; }
    [Parameter]
    public bool HasTrailingIcon { get; set; }
    [Parameter]
    public string? SupportingText { get; set; }
    [Parameter]
    public string? TextDirection { get; set; }
    [Parameter]
    public int? Rows { get; set; }
    [Parameter]
    public string? InputMode { get; set; }
    [Parameter]
    public string? Max { get; set; }
    [Parameter]
    public int? MaxLength { get; set; }
    [Parameter]
    public string? Min { get; set; }
    [Parameter]
    public int? MinLength { get; set; }
    [Parameter]
    public string? Pattern { get; set; }
    [Parameter]
    public string? Placeholder { get; set; }
    [Parameter]
    public bool ReadOnly { get; set; }
    [Parameter]
    public string? Step { get; set; }

    [Parameter]
    public TValue? Value { get; set; }

    [Parameter]
    public EventCallback<TValue?> ValueChanged { get; set; }

    [Parameter]
    public MdTextFieldInvalidBehavior InvalidBehavior { get; set; } = MdTextFieldInvalidBehavior.Ignore;

    string TagName => TextFieldStyle switch
    {
        MdTextFieldStyle.Filled => "md-filled-text-field",
        MdTextFieldStyle.Outlined => "md-outlined-text-field",
        _ => throw new NotImplementedException("Unknown style: " + TextFieldStyle.ToString()),
    };

    async Task OnValueChanged(ChangeEventArgs e)
    {
        TValue? value;
        try
        {
            value = (TValue?)Convert.ChangeType(e.Value, typeof(TValue));
        }
        catch (FormatException)
        {
            switch (InvalidBehavior)
            {
                case MdTextFieldInvalidBehavior.Ignore:
                    return;
                case MdTextFieldInvalidBehavior.DefaultValue:
                    value = default;
                    break;
                case MdTextFieldInvalidBehavior.Throw:
                default:
                    throw;
            }
        }

        await ValueChanged.InvokeAsync(value);
        Value = value;
    }

    public async Task<bool> CheckValidityAsync() =>
        await Js.InvokeElementMethodAsync<bool>(el, "checkValidity");

    public async Task<bool> ReportValidityAsync() =>
        await Js.InvokeElementMethodAsync<bool>(el, "reportValidity");

    public async Task SelectAsync() =>
        await InvokeAsync("select");

    public async Task SetCustomValidityAsync(string error) =>
        await InvokeAsync("setCustomValidity", error);

    public async Task SetRangeTextAsync(string replacement, int? start = null, int? end = null, MdTextFieldSetRangeTextSelectMode? selectMode = null) =>
        await InvokeAsync("setRangeText", replacement, start, end, selectMode?.ToString().ToLowerInvariant());

    public async Task SetSelectionRangeAsync(int start, int end, MdTextFieldSetSelectionRangeDirection? selectionDirection) =>
        await InvokeAsync("setSelectionRange", start, end, selectionDirection?.ToString().ToLowerInvariant());

    public async Task StepDownAsync(double? n) =>
        await InvokeAsync("stepDown", n);

    public async Task StepUpAsync(double? n) =>
        await InvokeAsync("stepUp", n);

    public async Task ResetAsync() =>
        await InvokeAsync("reset");

    async Task InvokeAsync(string methodName, params object?[] parameters) =>
        await Js.InvokeElementMethodAsync(el, methodName, parameters);

}

public enum MdTextFieldInvalidBehavior
{
    Ignore,
    Throw,
    DefaultValue,
}

/// <summary>
/// Blazor Material Web merges the components.
/// </summary>
public enum MdTextFieldStyle
{
    Filled,
    Outlined,
}

/// <summary>
/// From text-field.ts
/// </summary>
public class MdTextFieldTypes
{
    public const string Email = "email";
    public const string Number = "number";
    public const string Password = "password";
    public const string Search = "search";
    public const string Tel = "tel";
    public const string Text = "text";
    public const string Url = "url";
    public const string TextArea = "textarea";
}

public enum MdTextFieldSetRangeTextSelectMode
{
    Select,
    Start,
    End,
    Preserve,
}

public enum MdTextFieldSetSelectionRangeDirection
{
    None,
    Forward,
    Backward,
}