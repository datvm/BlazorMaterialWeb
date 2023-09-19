export function afterStarted() {

    const obs = new MutationObserver((e) => {
        if (e.some(record => {
            for (const node of record.addedNodes) {
                if (node?.querySelector?.("code")) {
                    return true;
                }
            }

            return false;
        })) 
        {
            hljs.highlightAll();
        }
    });

    obs.observe(document.body, {
        childList: true,
        subtree: true,
    });

}