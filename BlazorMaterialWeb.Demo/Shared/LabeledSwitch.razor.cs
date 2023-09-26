namespace BlazorMaterialWeb.Demo.Shared;

partial class LabeledSwitch
{

    [Parameter]
    public bool Selected { get; set; }

    [Parameter]
    public EventCallback<bool> SelectedChanged { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter, EditorRequired]
    public string Label { get; set; } = null!;

    async Task OnSelectedChanged()
    {
        await SelectedChanged.InvokeAsync(Selected);
    }

}
