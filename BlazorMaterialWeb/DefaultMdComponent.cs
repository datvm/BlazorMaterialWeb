namespace BlazorMaterialWeb;
public class DefaultMdComponent : ComponentBase
{

    protected ElementReference el;
    public ElementReference ElementReference => el;

    [Parameter(CaptureUnmatchedValues = true)]
    public IEnumerable<KeyValuePair<string, object?>>? AdditionalAttributes { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }
    
}

public class DefaultInheritableComponent : DefaultMdComponent
{

    protected virtual IEnumerable<KeyValuePair<string, object?>>? ProtectedAdditionalAttributes
        => null;
    
    protected IEnumerable<KeyValuePair<string, object?>>? FinalAdditionalAttributes
    {
        get
        {
            if (AdditionalAttributes is null) { return ProtectedAdditionalAttributes; } 
            if (ProtectedAdditionalAttributes is null) { return AdditionalAttributes; }

            return AdditionalAttributes.Concat(ProtectedAdditionalAttributes);
        }
    }

}