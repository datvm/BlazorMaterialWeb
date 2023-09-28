namespace BlazorMaterialWeb;

partial class MdSubMenu
{

    public const string ItemSlot = "item";
    public const string MenuSlot = "menu";

    [Parameter]
    public MdMenuCorner? AnchorCorner { get; set; }

    [Parameter]
    public MdMenuCorner? MenuCorner { get; set; }

    [Parameter]
    public int? HoverOpenDelay { get; set; }

    [Parameter]
    public int? HoverCloseDelay { get; set; }

}
