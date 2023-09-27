namespace BlazorMaterialWeb.Demo.Shared;

partial class LabeledRadio<TValue>
{

    [Parameter]
    public string? Label { get; set; }

    [Parameter, EditorRequired]
    public TValue? Value { get; set; }

}
