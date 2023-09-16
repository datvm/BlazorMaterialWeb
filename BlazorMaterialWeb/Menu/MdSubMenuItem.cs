namespace BlazorMaterialWeb;

public class MdSubMenuItem : MdMenuItem
{
    public const string SubmenuSlot = "submenu";

    [Parameter]
    public MdMenuCorner? AnchorCorner { get; set; }

    [Parameter]
    public MdMenuCorner? MenuCorner { get; set; }

    [Parameter]
    public int? HoverOpenDelay { get; set; }

    [Parameter]
    public int? HoverCloseDelay { get; set; }

    [Parameter]
    public bool Selected { get; set; }

    protected override string TagName => "md-sub-menu-item";

    protected override IEnumerable<KeyValuePair<string, object?>>? ProtectedAdditionalAttributes => 
        new KeyValuePair<string, object?>[] 
        {
            new ("anchor-corner", AnchorCorner),
            new ("menu-corner", MenuCorner),
            new ("hover-open-delay", HoverOpenDelay),
            new ("hover-close-delay", HoverCloseDelay),
            new ("selected", Selected),
        };

}
