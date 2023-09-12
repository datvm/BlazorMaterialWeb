export function afterStarted(blazor) {
    blazor.registerCustomEventType("oncheckedchange", {
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
}