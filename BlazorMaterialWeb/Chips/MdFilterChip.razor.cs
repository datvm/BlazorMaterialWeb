namespace BlazorMaterialWeb;

partial class MdFilterChip
{

    [Parameter]
    public bool Removable { get; set; }

    [Parameter]
    public bool Selected { get; set; }

    [Parameter]
    public EventCallback<bool> SelectedChanged { get; set; }

    [Parameter]
    public EventCallback OnRemove { get; set; }

    async Task OnSelectedChanged(CheckedEventArgs e)
    {
        Selected = e.Checked;
        await SelectedChanged.InvokeAsync(Selected);
    }

}
