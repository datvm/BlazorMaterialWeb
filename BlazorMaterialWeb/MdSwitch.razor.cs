namespace BlazorMaterialWeb;

/// <summary>
/// Switches toggle the state of an item on or off.
/// <a href="https://m3.material.io/components/switch/overview">Design</a>,
/// <a href="https://material-web.dev/components/switch/">Component</a>,
/// </summary>
partial class MdSwitch
{

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public bool Selected { get; set; }

    [Parameter]
    public EventCallback<bool> SelectedChanged { get; set; }

    [Parameter]
    public bool Icons { get; set; }

    [Parameter]
    public bool ShowOnlySelectedIcon { get; set; }

    [Parameter]
    public bool Required { get; set; }

    [Parameter]
    public string? Value { get; set; }

    async Task OnSelectedChanged(CheckedEventArgs e)
    {
        Selected = e.Checked;
        await SelectedChanged.InvokeAsync(Selected);
    }

}
