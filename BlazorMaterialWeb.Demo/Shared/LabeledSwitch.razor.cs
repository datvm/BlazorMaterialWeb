namespace BlazorMaterialWeb.Demo.Shared;

partial class LabeledSwitch
{

    [Parameter]
    public bool Selected { get; set; }

    [Parameter]
    public EventCallback<bool> SelectedChanged { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public string? Label { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    async Task OnSelectedChanged()
    {
        await SelectedChanged.InvokeAsync(Selected);
    }

}
