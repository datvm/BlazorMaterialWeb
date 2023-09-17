using Microsoft.AspNetCore.Components.Rendering;

namespace BlazorMaterialWeb;

// Thanks to https://stackoverflow.com/a/64197278/653457
public class DynamicTag : DefaultMdComponent
{

    [Parameter, EditorRequired]
    public string Tag { get; set; } = null!;

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, Tag);

        if (AdditionalAttributes?.Any() == true)
        {
            builder.AddMultipleAttributes(1, 
                AdditionalAttributes.Where(q => q.Value is not null)!);
        }

        if (ChildContent is not null)
        {
            builder.AddContent(2, ChildContent);
        }

        builder.CloseElement();
    }

}
