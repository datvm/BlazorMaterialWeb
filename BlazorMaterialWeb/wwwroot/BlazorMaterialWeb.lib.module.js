export function afterStarted(blazor) {
    blazor.registerCustomEventType("checkedchange", {
        browserEventName: "change",
        createEventArgs: ({ target }) => {
            if (target.disabled) {
                return null;
            }
            return {
                checked: target.checked,
                indeterminate: target.indeterminate,
            };
        }
    });

    blazor.registerCustomEventType("selected", {
        browserEventName: "selected",
        createEventArgs: e => ({
            checked: e.target.selected
        }),
    });

    blazor.registerCustomEventType("remove", {
        browserEventName: "remove",
        createEventArgs: () => undefined,
    });
}