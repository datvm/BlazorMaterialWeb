namespace BlazorMaterialWeb;

/// <summary>
/// Sliders let users make selections from a range of values.
/// <a href="https://m3.material.io/components/sliders/overview">Design</a>,
/// <a href="https://material-web.dev/components/slider/">Component</a>
/// </summary>
partial class MdSlider
{
    [Parameter]
    public bool Disabled { get; set; } = false;

    [Parameter]
    public double? Min { get; set; } = 0;

    [Parameter]
    public double? Max { get; set; } = 100;

    [Parameter]
    public double Value { get; set; }

    [Parameter]
    public EventCallback<double> ValueChanged { get; set; }

    [Parameter]
    public EventCallback<double> ValueInput { get; set; }

    [Parameter]
    public double ValueStart { get; set; }

    [Parameter]
    public EventCallback<double> ValueStartChanged { get; set; }

    [Parameter]
    public EventCallback<double> ValueStartInput { get; set; }

    [Parameter]
    public double ValueEnd { get; set; }

    [Parameter]
    public EventCallback<double> ValueEndChanged { get; set; }

    [Parameter]
    public EventCallback<double> ValueEndInput { get; set; }

    [Parameter]
    public EventCallback<(double Start, double End)> RangeChanged { get; set; }

    [Parameter]
    public EventCallback<(double Start, double End)> RangeInput { get; set; }

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
    public double? Step { get; set; }

    [Parameter]
    public bool Ticks { get; set; }

    [Parameter]
    public bool Labeled { get; set; }

    [Parameter]
    public bool Range { get; set; }

    async Task OnSliderInput(MdSliderChangeEventArgs e)
    {
        SetValue(e);

        await ValueInput.InvokeAsync(e.Value);
        await ValueStartInput.InvokeAsync(e.ValueStart);
        await ValueEndInput.InvokeAsync(e.ValueEnd);
        await RangeInput.InvokeAsync((e.ValueStart, e.ValueEnd));
    }

    async Task OnSliderValueChanged(MdSliderChangeEventArgs e)
    {
        SetValue(e);

        await ValueChanged.InvokeAsync(e.Value);
        await ValueStartChanged.InvokeAsync(e.ValueStart);
        await ValueEndChanged.InvokeAsync(e.ValueEnd);
        await RangeChanged.InvokeAsync((e.ValueStart, e.ValueEnd));
    }

    void SetValue(MdSliderChangeEventArgs e)
    {
        Value = e.Value;
        ValueStart = e.ValueStart;
        ValueEnd = e.ValueEnd;
    }

}
