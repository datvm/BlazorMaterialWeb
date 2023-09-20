namespace BlazorMaterialWeb;

/// <summary>
/// Progress indicators show the status of a process in real time.
/// <a href="https://m3.material.io/components/progress-indicators/overview">Design</a>
/// <a href="https://material-web.dev/components/progress/">Component</a>
/// </summary>
partial class MdProgress
{

    [Parameter]
    public MdProgressStyle ProgressStyle { get; set; } = MdProgressStyle.Linear;

    [Parameter]
    public double? Buffer { get; set; }

    [Parameter]
    public double? Value { get; set; }

    [Parameter]
    public double? Max { get; set; }

    [Parameter]
    public bool Indeterminate { get; set; }

    [Parameter]
    public bool FourColor { get; set; }

    string TagName => ProgressStyle switch
    {
        MdProgressStyle.Circular => "md-circular-progress",
        MdProgressStyle.Linear => "md-linear-progress",
        _ => throw new NotImplementedException("Unknown style: " + ProgressStyle),
    };
}

public enum MdProgressStyle
{
    Circular,
    Linear,
}