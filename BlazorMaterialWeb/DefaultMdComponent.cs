namespace BlazorMaterialWeb;

public abstract class BaseDefaultMdComponent : ComponentBase
{
    protected ElementReference el;
    public ElementReference ElementReference => el;

    [Parameter(CaptureUnmatchedValues = true)]
    public IEnumerable<KeyValuePair<string, object?>>? AdditionalAttributes { get; set; }
}

public class DefaultMdComponent : BaseDefaultMdComponent
{

    [Parameter]
    public RenderFragment? ChildContent { get; set; }
    
}

public class DefaultMdComponent<TValue> : BaseDefaultMdComponent
{

    [Parameter]
    public RenderFragment<TValue>? ChildContent { get; set; }

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