namespace BlazorMaterialWeb;

partial class MdInputChip
{

    [Parameter]
    public bool Avatar { get; set; }

    [Parameter]
    public string? Href { get; set; }

    [Parameter]
    public string? Target { get; set; }

    [Parameter]
    public bool RemoveOnly { get; set; }

    [Parameter]
    public bool Selected { get; set; }

    [Parameter]
    public EventCallback<bool> SelectedChanged { get; set; }

    [Parameter]
    public EventCallback OnRemove { get; set; }

    async Task OnSelectedChanged(MdCheckedEventArgs e)
    {
        Selected = e.Checked;
        await SelectedChanged.InvokeAsync(Selected);
    }

}
