namespace BlazorMaterialWeb;

partial class MdIconButton
{

    [Parameter]
    public MdIconButtonStyle Style { get; set; } = MdIconButtonStyle.Default;

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public bool FlipIconInRtl { get; set; }

    [Parameter]
    public string? Href { get; set; }

    [Parameter]
    public string? Target { get; set; }

    [Parameter]
    public string? AriaLabelSelected { get; set; }

    [Parameter]
    public bool Toggle { get; set; }

    [Parameter]
    public bool Selected { get; set; }

    [Parameter]
    public EventCallback<bool> SelectedChanged { get; set; }

    [Parameter]
    public string? Type { get; set; }

    [Parameter]
    public string? Value { get; set; }

    string TagName => Style switch
    {
        MdIconButtonStyle.Default => "md-icon-button",
        MdIconButtonStyle.Filled => "md-filled-icon-button",
        MdIconButtonStyle.Tonal => "md-filled-tonal-icon-button",
        MdIconButtonStyle.Outlined => "md-outlined-icon-button",
        _ => throw new NotImplementedException("Unknown style: " + Style.ToString()),
    };

    async Task OnSelectedChanged(CheckedEventArgs e)
    {
        Selected = e.Checked;
        await SelectedChanged.InvokeAsync(Selected);
    }

}

public enum MdIconButtonStyle
{
    Default,
    Filled,
    Tonal,
    Outlined,
}
