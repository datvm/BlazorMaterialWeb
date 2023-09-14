namespace BlazorMaterialWeb;

/// <summary>
/// Checkboxes let users select one or more items from a list, or turn an item on or off.
/// <a href="https://m3.material.io/components/checkbox/overview">Design</a>,
/// <a href="https://material-web.dev/components/checkbox/">Component</a>
/// </summary>
partial class MdCheckbox
{

    [Parameter]
    public bool Checked { get; set; }

    [Parameter]
    public EventCallback<bool> CheckedChanged { get; set; }

    [Parameter]
    public bool Indeterminate { get; set; }

    [Parameter]
    public EventCallback<bool> IndeterminateChanged { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public bool Required { get; set; }

    [Parameter]
    public string? Value { get; set; }

    async Task OnCheckedChanged(CheckboxChangeEventArgs e)
    {
        var intermediateChanged = e.Indeterminate != Indeterminate;

        Checked = e.Checked;
        Indeterminate = e.Indeterminate;

        await CheckedChanged.InvokeAsync(Checked);
        if (intermediateChanged)
        {
            await IndeterminateChanged.InvokeAsync(Indeterminate);
        }
    }

}
