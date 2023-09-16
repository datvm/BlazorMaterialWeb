namespace BlazorMaterialWeb;

public class MdMenuItem : MdListItem
{

    public override MdListItemRole Type
    {
        get => MdListItemRole.MenuItem;
        set => throw new InvalidOperationException();
    }

    [Parameter]
    public bool KeepOpen { get; set; }

    protected override IEnumerable<KeyValuePair<string, object?>>? ProtectedAdditionalAttributes =>
        new KeyValuePair<string, object?>[] {
            new("keep-open", KeepOpen),
        };

}
