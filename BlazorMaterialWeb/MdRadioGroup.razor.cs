namespace BlazorMaterialWeb;

partial class MdRadioGroup
{

    [Parameter, EditorRequired]
    public string Name { get; set; } = null!;

    [Parameter]
    public string? Value { get; set; }

    [Parameter]
    public EventCallback<string> ValueChanged { get; set; }

    async Task OnCheckedChanged(CheckedEventArgs e)
    {
        if (!e.Checked) { return; }

        Value = e.Value;
        await ValueChanged.InvokeAsync(Value);
    }

}
