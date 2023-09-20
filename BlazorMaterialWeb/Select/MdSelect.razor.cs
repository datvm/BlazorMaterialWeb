namespace BlazorMaterialWeb;

partial class MdSelect
{
    [Parameter]
    public MdSelectStyle SelectStyle { get; set; } = MdSelectStyle.Outlined;

    [Parameter]
    public bool Quick { get; set; }

    [Parameter]
    public bool Required { get; set; }

    [Parameter]
    public string? Value { get; set; }

    [Parameter]
    public EventCallback<string?> ValueChanged { get; set; }

    [Parameter]
    public int SelectedIndex { get; set; }

    [Parameter]
    public EventCallback<int> SelectedIndexChanged { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public string? ErrorText { get; set; }

    [Parameter]
    public string? Label { get; set; }

    [Parameter]
    public string? SupportingText { get; set; }

    [Parameter]
    public bool Error { get; set; }

    [Parameter]
    public bool MenuFixed { get; set; }

    [Parameter]
    public int? TypeaheadDelay { get; set; }

    [Parameter]
    public bool HasLeadingIcon { get; set; }

    [Parameter]
    public string? DisplayText { get; set; }

    [Parameter]
    public EventCallback<MdSelectChangeEventArgs> OnChange { get; set; }

    [Parameter]
    public EventCallback<MdSelectChangeEventArgs> OnInput { get; set; }

    async Task OnChangeAsync(MdSelectChangeEventArgs e)
    {
        if (e.Value != Value)
        {
            Value = e.Value;
            await ValueChanged.InvokeAsync(Value);
        }

        if (e.SelectedIndex != SelectedIndex)
        {
            SelectedIndex = e.SelectedIndex;
            await SelectedIndexChanged.InvokeAsync(SelectedIndex);
        }

        await OnChange.InvokeAsync(e);
    }

    string TagName => SelectStyle switch
    {
        MdSelectStyle.Outlined => "md-outlined-select",
        MdSelectStyle.Filled => "md-filled-select",
        _ => throw new NotImplementedException("Unknown style: " + SelectStyle),
    };
}

public enum MdSelectStyle
{
    Outlined,
    Filled,
}