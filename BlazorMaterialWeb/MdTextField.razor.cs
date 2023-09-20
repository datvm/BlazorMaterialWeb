namespace BlazorMaterialWeb;

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
    public string Type { get; set; } = MdTextFieldTypes.Text.ToString();
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
    public TValue? Max { get; set; }
    [Parameter]
    public int? MaxLength { get; set; }
    [Parameter]
    public TValue? Min { get; set; }
    [Parameter]
    public int? MinLength { get; set; }
    [Parameter]
    public string? Pattern { get; set; }
    [Parameter]
    public string? Placeholder { get; set; }
    [Parameter]
    public bool ReadOnly { get; set; }
    [Parameter]
    public TValue? Step { get; set; }

    [Parameter]
    public TValue? Value { get; set; }

    [Parameter]
    public EventCallback<TValue?> ValueChanged { get; set; }

    string TagName => TextFieldStyle switch
    {
        MdTextFieldStyle.Filled => "md-filled-text-field",
        MdTextFieldStyle.Outlined => "md-outlined-text-field",
        _ => throw new NotImplementedException("Unknown style: " + TextFieldStyle.ToString()),
    };

    async Task OnValueChanged(ChangeEventArgs e)
    {
        Value = (TValue?)Convert.ChangeType(e.Value, typeof(TValue));
        await ValueChanged.InvokeAsync(Value);
    }

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
    // Supported Types
    // 'email'|'number'|'password'|'search'|'tel'|'text'|'url'|'textarea';
    public const string Email = "email";
    public const string Number = "number";
    public const string Password = "password";
    public const string Search = "search";
    public const string Tel = "tel";
    public const string Text = "text";
    public const string Url = "url";
    public const string TextArea = "textarea";

    // Unsupported Types
    // 'color'|'date'|'datetime-local'|'file'|'month'|'time'|'week'
    public const string Color = "color";
    public const string Date = "date";
    public const string DateTimeLocal = "datetime-local";
    public const string File = "file";
    public const string Month = "month";
    public const string Time = "time";
    public const string Week = "week";
}