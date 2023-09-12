namespace BlazorMaterialWeb;

[EventHandler("oncheckedchange", typeof(CheckboxChangeEventArgs), enableStopPropagation: true, enablePreventDefault: true)]
[EventHandler("onselected", typeof(CheckedEventArgs), enableStopPropagation: true, enablePreventDefault: true)]
[EventHandler("onremove", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
public static class EventHandlers { }

public class CheckedEventArgs : EventArgs
{
    public bool Checked { get; set; }
}

public class CheckboxChangeEventArgs : CheckedEventArgs
{
    public bool Indeterminate { get; set; }
}
