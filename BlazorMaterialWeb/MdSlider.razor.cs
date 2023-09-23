namespace BlazorMaterialWeb;

/// <summary>
/// Sliders let users make selections from a range of values.
/// <a href="https://m3.material.io/components/sliders/overview">Design</a>,
/// <a href="https://material-web.dev/components/slider/">Component</a>
/// </summary>
partial class MdSlider<TValue>
{
    [Parameter]
    public bool Disabled { get; set; } = false;

    [Parameter]
    public string? Min { get; set; }

    [Parameter]
    public string? Max { get; set; }

    [Parameter]
    public TValue? Value { get; set; }

    [Parameter]
    public EventCallback<TValue?> ValueChanged { get; set; }

    [Parameter]
    public EventCallback<TValue?> ValueInput { get; set; }

    [Parameter]
    public TValue? ValueStart { get; set; }

    [Parameter]
    public EventCallback<TValue?> ValueStartChanged { get; set; }

    [Parameter]
    public EventCallback<TValue?> ValueStartInput { get; set; }

    [Parameter]
    public TValue? ValueEnd { get; set; }

    [Parameter]
    public EventCallback<TValue?> ValueEndChanged { get; set; }

    [Parameter]
    public EventCallback<TValue?> ValueEndInput { get; set; }

    [Parameter]
    public EventCallback<(TValue? Start, TValue? End)> RangeChanged { get; set; }

    [Parameter]
    public EventCallback<(TValue? Start, TValue? End)> RangeInput { get; set; }

    [Parameter]
    public string? ValueLabel { get; set; }

    [Parameter]
    public string? ValueLabelStart { get; set; }

    [Parameter]
    public string? ValueLabelEnd { get; set; }

    [Parameter]
    public string? AriaLabelStart { get; set; }

    [Parameter]
    public string? AriaValueTextStart { get; set; }

    [Parameter]
    public string? AriaLabelEnd { get; set; }

    [Parameter]
    public string? AriaValueTextEnd { get; set; }

    [Parameter]
    public TValue? Step { get; set; }

    [Parameter]
    public bool Ticks { get; set; }

    [Parameter]
    public bool Labeled { get; set; }

    [Parameter]
    public bool Range { get; set; }

    async Task OnSliderInput(MdSliderChangeEventArgs e)
    {
        SetValue(e);

        await ValueInput.InvokeAsync(Value);
        await ValueStartInput.InvokeAsync(ValueStart);
        await ValueEndInput.InvokeAsync(ValueEnd);
        await RangeInput.InvokeAsync((ValueStart, ValueEnd));
    }

    async Task OnSliderValueChanged(MdSliderChangeEventArgs e)
    {
        SetValue(e);

        await ValueChanged.InvokeAsync(Value);
        await ValueStartChanged.InvokeAsync(ValueStart);
        await ValueEndChanged.InvokeAsync(ValueEnd);
        await RangeChanged.InvokeAsync((ValueStart, ValueEnd));
    }

    void SetValue(MdSliderChangeEventArgs e)
    {
        Value = GetValue(e.Value);
        ValueStart = GetValue(e.ValueStart);
        ValueEnd = GetValue(e.ValueEnd);
    }

    static TValue? GetValue(double value) =>
        (TValue?)Convert.ChangeType(value, typeof(TValue?));
}
