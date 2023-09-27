export function beforeStart() {
    globalThis.BlazorMaterialWeb ??= new class {

        constructor() {
            this.#overrideDispatch();
            this.#observeChips();
        }

        getElementProperty(element, propertyName) {
            return element[propertyName];
        }

        setElementProperty(element, propertyName, value) {
            element[propertyName] = value;
        }

        async invokeElementMethodAsync(element, methodName, ...args) {
            return await element[methodName](...args);
        }

        #overrideDispatch() {
            const original = EventTarget.prototype.dispatchEvent;

            EventTarget.prototype.dispatchEvent = function (event) {
                let arg = event;

                if (!event.bubbles && this.tagName?.startsWith("MD-")) {
                    arg = new CustomEvent(event.type, {
                        bubbles: true,
                        detail: event.detail,
                        cancelable: event.cancelable,
                        composed: event.composed,
                    });
                }

                return original.call(this, arg);
            }
        }

        #observeChips() {
            const obs = new MutationObserver(changes => {
                for (const change of changes) {
                    const name = change.target.nodeName.toUpperCase();
                    if (name.startsWith("MD") && name.endsWith("CHIP")) {
                        const chip = change.target;
                        chip.dispatchEvent(new CustomEvent("selected", {
                            bubbles: true,
                            detail: {
                                value: chip.value,
                                checked: chip.selected,
                            }
                        }));
                    }
                }
            });

            obs.observe(document.body, {
                attributeFilter: ["selected"],
                attributes: true,
                subtree: true,
            })
        }
    }();
}

export function afterStarted(blazor) {
    function createCheckEventArgs(target, hasIndeterminate) {
        const result = {
            value: target.value,
            checked: Boolean(target.checked || target.selected),
        };

        if (hasIndeterminate) {
            result.indeterminate = Boolean(target.indeterminate);
        }

        return result;
    }

    blazor.registerCustomEventType("checkedchange", {
        browserEventName: "change",
        createEventArgs: ({ target }) => createCheckEventArgs(target, true),
    });

    blazor.registerCustomEventType("radiochecked", {
        browserEventName: "change",
        createEventArgs: ({ target }) => createCheckEventArgs(target),
    });

    blazor.registerCustomEventType("switchchange", {
        browserEventName: "change",
        createEventArgs: ({ target }) => createCheckEventArgs(target),
    });

    blazor.registerCustomEventType("chipselected", {
        browserEventName: "selected",
        createEventArgs: ({ target }) => createCheckEventArgs(target),
    });

    blazor.registerCustomEventType("chipremove", {
        browserEventName: "remove",
        createEventArgs: () => null,
    });

    blazor.registerCustomEventType("diagopen", {
        browserEventName: "open",
        createEventArgs: () => ({}),
    });

    blazor.registerCustomEventType("diagopened", {
        browserEventName: "opened",
        createEventArgs: () => ({}),
    });

    blazor.registerCustomEventType("diagclose", {
        browserEventName: "close",
        createEventArgs: e => ({
            returnValue: e.target.returnValue,
        }),
    });

    blazor.registerCustomEventType("diagclosed", {
        browserEventName: "closed",
        createEventArgs: e => ({
            returnValue: e.target.returnValue,
        }),
    });

    blazor.registerCustomEventType("diagcancel", {
        browserEventName: "cancel",
        createEventArgs: () => null,
    });

    blazor.registerCustomEventType("sliderchange", {
        browserEventName: "change",
        createEventArgs: ({ target }) => ({
            value: target.value,
            valueStart: target.valueStart,
            valueEnd: target.valueEnd,
        }),
    });

    blazor.registerCustomEventType("sliderinput", {
        browserEventName: "input",
        createEventArgs: ({ target }) => ({
            value: target.value,
            valueStart: target.valueStart,
            valueEnd: target.valueEnd,
        }),
    });

    blazor.registerCustomEventType("tabchanged", {
        browserEventName: "change",
        createEventArgs: ({ target }) => {
            const tab = target.activeTab;

            tab.dispatchEvent("activated");

            return {
                index: target.activeTabIndex,
            };
        },
    });

    blazor.registerCustomEventType("tabactivated", {
        browserEventName: "activated",
        createEventArgs: ({ target }) => ({
            checked: target.active,
        }),
    });

    blazor.registerCustomEventType("listitemrequestactivation", {
        browserEventName: "request-activation",
        createEventArgs: ({ target }) => ({
            checked: target.active,
        }),
    });

}