namespace BlazorMaterialWeb;

partial class MdElevation
{

    [Parameter]
    public string? BorderRadius { get; set; }

    [Parameter, EditorRequired]
    public int ElevationLevel { get; set; }

    string StyleOutput => string.Join(";",
        $"--md-elevation-level: {ElevationLevel};",
        BorderRadius is null ? null : $"--md-elevation-border-radius: {BorderRadius}");

}
