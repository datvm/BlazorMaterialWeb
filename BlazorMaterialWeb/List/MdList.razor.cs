namespace BlazorMaterialWeb;

/// <summary>
/// Lists are continuous, vertical indexes of text and images.
/// <a href="https://m3.material.io/components/lists/overview">Design</a>,
/// <a href="https://material-web.dev/components/list/">Component</a>
/// </summary>
partial class MdList
{

    [Parameter]
    public MdListType Type { get; set; } = MdListType.List;

    [Parameter]
    public int? ListTabIndex { get; set; }

}

/// <summary>
/// From list.ts
/// </summary>
public enum MdListType
{
    Menu,
    MenuBar,
    ListBox,
    List,
}