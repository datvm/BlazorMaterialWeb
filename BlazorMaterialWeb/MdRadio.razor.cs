namespace BlazorMaterialWeb;

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

    async Task OnCheckedChanged(CheckedEventArgs e)
    {
        Checked = e.Checked;
        await CheckedChanged.InvokeAsync(Checked);
    }

}
