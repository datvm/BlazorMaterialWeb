namespace BlazorMaterialWeb;

/// <summary>
/// Input chips are pieces of information entered by a user, such as event attendees.
/// <a href="https://m3.material.io/components/chips/overview">Design</a>,
/// <a href="https://material-web.dev/components/chip/">Component</a>
/// </summary>
public class MdInputChip : BaseMdInteractiveChip
{

    [Parameter]
    public bool Avatar { get; set; }

    [Parameter]
    public string? Href { get; set; }

    [Parameter]
    public string? Target { get; set; }

    [Parameter]
    public bool RemoveOnly { get; set; }

    protected override string TagName => "md-input-chip";

    protected override IEnumerable<KeyValuePair<string, object?>> ProtectedAdditionalAttributes => 
        new KeyValuePair<string, object?>[]
        {
            new("avatar", Avatar),
            new("href", Href),
            new("target", Target),
            new("remove-only", RemoveOnly),
        }.Concat(base.ProtectedAdditionalAttributes);

}
