namespace BlazorMaterialWeb;

partial class MdElevation
{

    [Parameter, EditorRequired]
    public int ElevationLevel { get; set; }

    [Parameter]
    public string Style { get; set; } = "";

    // Do not put a ; at the end
    string InternalStyleOutput => $"--md-elevation-level: {ElevationLevel}";

    string FinalStyle =>
        $"{InternalStyleOutput};{Style}";

}
