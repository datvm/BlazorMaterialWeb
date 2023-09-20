using Microsoft.AspNetCore.Components.Rendering;

namespace BlazorMaterialWeb;

// Thanks to https://stackoverflow.com/a/64197278/653457
public class DynamicTag : DefaultMdComponent
{

    [Parameter, EditorRequired]
    public string Tag { get; set; } = null!;

    [Parameter]
    public ElementReference DynamicElementReference { get; set; }

    [Parameter]
    public EventCallback<ElementReference> DynamicElementReferenceChanged { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, Tag);
        

        if (AdditionalAttributes?.Any() == true)
        {
            builder.AddMultipleAttributes(1,
                AdditionalAttributes.Where(q => q.Value is not null)!);
        }

        builder.AddElementReferenceCapture(2, async (ElementReference element) =>
        {
            el = element;
            DynamicElementReference = element;
            await DynamicElementReferenceChanged.InvokeAsync(element);
        });

        if (ChildContent is not null)
        {
            builder.AddContent(3, ChildContent);
        }

        builder.CloseElement();
    }

}
