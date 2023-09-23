namespace BlazorMaterialWeb;

partial class MdRadioGroup<TValue>
{

    [Parameter, EditorRequired]
    public string Name { get; set; } = null!;

    [Parameter]
    public TValue? Value { get; set; }

    [Parameter]
    public EventCallback<TValue?> ValueChanged { get; set; }

    async Task OnCheckedChanged(MdCheckedEventArgs e)
    {
        var parsed = (TValue?)Convert.ChangeType(e.Value, typeof(TValue));
        if (!e.Checked || parsed?.Equals(Value) == true) { return; }

        Value = parsed;
        await ValueChanged.InvokeAsync(parsed);
    }

    bool RadioCheckGroup(TValue? value) =>
        value is not null && value.Equals(Value);

}
