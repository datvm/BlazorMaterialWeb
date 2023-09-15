namespace BlazorMaterialWeb;

/// <summary>
/// Radio buttons let people select one option from a set of options.
/// <a href="https://m3.material.io/components/radio-button/overview">Design</a>,
/// <a href="https://material-web.dev/components/radio/">Component</a>,
/// </summary>
partial class MdRadio
{

    [Parameter]
    public bool Checked { get; set; }

    [Parameter]
    public EventCallback<bool> CheckedChanged { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public string? Value { get; set; }

    [Parameter, CascadingParameter(Name = "MdRadioName")]
    public string? Name { get; set; }

    async Task OnCheckedChanged(CheckedEventArgs e)
    {
        Checked = e.Checked;
        await CheckedChanged.InvokeAsync(Checked);
    }

}
