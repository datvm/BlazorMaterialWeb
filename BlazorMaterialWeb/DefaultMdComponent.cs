namespace BlazorMaterialWeb;
public class DefaultMdComponent : ComponentBase
{

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

}
