namespace BlazorMaterialWeb;

/// <summary>
/// Radio buttons let people select one option from a set of options.
/// <a href="https://m3.material.io/components/radio-button/overview">Design</a>,
/// <a href="https://material-web.dev/components/radio/">Component</a>,
/// </summary>
partial class MdRadio<TValue>
{

    [Parameter]
    public bool Checked { get; set; }

    [Parameter]
    public EventCallback<bool> CheckedChanged { get; set; }

    [Parameter]
    public EventCallback<MdCheckedEventArgs> OnChecked { get; set;}

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public TValue? Value { get; set; }

    [Parameter]
    public string? Name { get; set; }

    [CascadingParameter(Name = "MdRadioName")]
    public string? GroupName { get; set; }

    [CascadingParameter(Name = "MdRadioChecked")]
    public Func<TValue?, bool>? GroupChecked { get; set; }

    async Task OnDomCheckedChangedAsync(MdCheckedEventArgs e)
    {
        Checked = e.Checked;
        await CheckedChanged.InvokeAsync(Checked);
        
        if (Checked)
        {
            await OnChecked.InvokeAsync(e);
        }
    }

    bool IsChecked() =>
        Checked ||
        GroupChecked?.Invoke(Value) == true;

}
