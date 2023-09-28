namespace BlazorMaterialWeb;

public class MdSelect
{

    public const string StartSlot = "start";
    public const string EndSlot = "end";
    public const string LeadingIconSlot = "leading-icon";

}

/// <summary>
/// Select menus display a list of choices on temporary surfaces and display the currently selected menu item above the menu.
/// <a href="https://material-web.dev/components/select/">Component</a>
/// </summary>
partial class MdSelect<TValue>
{

    [Parameter]
    public MdSelectStyle SelectStyle { get; set; } = MdSelectStyle.Outlined;

    [Parameter]
    public TValue? Value { get; set; }

    [Parameter]
    public EventCallback<TValue?> ValueChanged { get; set; }

    [Parameter]
    public bool Quick { get; set; }

    [Parameter]
    public bool Required { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public string? ErrorText { get; set; }

    [Parameter]
    public string? Label { get; set; }

    [Parameter]
    public string? SupportingText { get; set; }

    [Parameter]
    public bool Error { get; set; }

    [Parameter]
    public MdMenuPositioning? MenuPositioning { get; set; }

    [Parameter]
    public int? TypeaheadDelay { get; set; }

    [Parameter]
    public bool HasLeadingIcon { get; set; }

    [Parameter]
    public string? DisplayText { get; set; }

    [Parameter]
    public int SelectedIndex { get; set; }

    [Parameter]
    public EventCallback<int> SelectedIndexChanged { get; set; }

    [Parameter]
    public EventCallback<MdSelectChangeEventArgs> OnChange { get; set; }

    [Parameter]
    public EventCallback<MdSelectChangeEventArgs> OnInput { get; set; }

    [Parameter]
    public EventCallback OnOpening { get; set; }

    [Parameter]
    public EventCallback OnOpened { get; set; }

    [Parameter]
    public EventCallback OnClosing { get; set; }

    [Parameter]
    public EventCallback OnClosed { get; set; }

    async Task OnChangeAsync(MdSelectChangeEventArgs e)
    {
        TValue? value;
        try
        {
            value = (TValue?)Convert.ChangeType(e.Value, typeof(TValue));
        }
        catch (Exception ex)
        {
            if (ex is FormatException || ex is InvalidCastException)
            {
                return;
            }

            throw;
        }

        if (value?.Equals(Value) != true)
        {
            Value = value;
            await ValueChanged.InvokeAsync(value);
        }

        if (e.SelectedIndex != SelectedIndex)
        {
            SelectedIndex = e.SelectedIndex;
            await SelectedIndexChanged.InvokeAsync(SelectedIndex);
        }

        await OnChange.InvokeAsync(e);
    }

    public async Task<IJSObjectReference> GetOptionsAsync() =>
        await Js.GetElementPropertyAsync<IJSObjectReference>(el, "options");

    public async Task<IJSObjectReference> GetSelectedOptionsAsync() =>
        await Js.GetElementPropertyAsync<IJSObjectReference>(el, "selectedOptions");

    public async Task ResetAsync() =>
        await InvokeElAsync("reset");

    public async Task<bool> CheckValidityAsync() =>
        await InvokeElAsync<bool>("checkValidity");

    public async Task ReportValidityAsync() =>
        await InvokeElAsync("reportValidity");

    public async Task SetCustomValidityAsync(string message) =>
        await InvokeElAsync("setCustomValidity", message);

    async Task InvokeElAsync(string name, params object[] args) =>
        await Js.InvokeElementMethodAsync(el, name, args);

    async Task<T> InvokeElAsync<T>(string name, params object[] args) =>
        await Js.InvokeElementMethodAsync<T>(el, name, args);

    string TagName => SelectStyle switch
    {
        MdSelectStyle.Outlined => "md-outlined-select",
        MdSelectStyle.Filled => "md-filled-select",
        _ => throw new NotImplementedException("Unknown style: " + SelectStyle),
    };
}

/// <summary>
/// Provide by Blazor to merge two styles
/// </summary>
public enum MdSelectStyle
{
    Outlined,
    Filled,
}

/// <summary>
/// From select.ts
/// </summary>
public enum MdSelectPositioning
{
    Absolute,
    Fixed,
}