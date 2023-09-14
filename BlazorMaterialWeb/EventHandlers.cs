namespace BlazorMaterialWeb;

// Checkbox
[EventHandler("oncheckedchange", typeof(CheckboxChangeEventArgs), enableStopPropagation: true, enablePreventDefault: true)]

// Chip
// TODO: onremove is not working: https://github.com/material-components/material-web/issues/4905
[EventHandler("onselected", typeof(CheckedEventArgs), enableStopPropagation: true, enablePreventDefault: true)]
[EventHandler("onremove", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]

// Dialog
[EventHandler("onopen", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
[EventHandler("onopened", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
[EventHandler("onclose", typeof(DialogReturnEventArgs), enableStopPropagation: true, enablePreventDefault: true)]
[EventHandler("onclosed", typeof(DialogReturnEventArgs), enableStopPropagation: true, enablePreventDefault: true)]
[EventHandler("oncancel", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
public static class EventHandlers { }

public class CheckedEventArgs : EventArgs
{
    public bool Checked { get; set; }
}

public class CheckboxChangeEventArgs : CheckedEventArgs
{
    public bool Indeterminate { get; set; }
}

public class DialogReturnEventArgs : EventArgs
{

    public string ReturnValue { get; set; } = "";

}