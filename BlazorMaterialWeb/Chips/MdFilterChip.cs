namespace BlazorMaterialWeb;

/// <summary>
/// Filter chips are tags used to filter content, such as shopping categories.
/// <a href="https://m3.material.io/components/chips/overview">Design</a>,
/// <a href="https://material-web.dev/components/chip/">Component</a>
/// </summary>
public class MdFilterChip : BaseMdInteractiveChip
{

    [Parameter]
    public bool Elevated { get; set; }

    [Parameter]
    public bool Removable { get; set; }

    protected override string TagName => "md-filter-chip";

    protected override IEnumerable<KeyValuePair<string, object?>> ProtectedAdditionalAttributes =>
        new KeyValuePair<string, object?>[]
        {
            new("elevated", Elevated),
            new("removable", Removable),
        }
        .Concat(base.ProtectedAdditionalAttributes);

}
