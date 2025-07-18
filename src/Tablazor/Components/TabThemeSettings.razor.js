
export class TablazorTheme {

    static config = {};
    
    static items = {
        "menu-position": { localStorage: "tablerMenuPosition", default: "top" },
        "menu-behavior": { localStorage: "tablerMenuBehavior", default: "sticky" },
        "container-layout": {
            localStorage: "tablerContainerLayout",
            default: "boxed",
        },
    };
    
    static initialize() {
        for (const [key, params] of Object.entries(this.items)) {
            const lsParams = localStorage.getItem(params.localStorage)
            this.config[key] = lsParams ? lsParams : params.default
        }

        const submitButton = document.getElementById('themeSave');
        if (submitButton !== null)
        {
            submitButton.addEventListener('click', this.submitForm);
        }

        const resetButton = document.getElementById('themeReset');
        if (resetButton !== null)
        {
            resetButton.addEventListener('click', this.resetForm);
        }
        
        this.toggleFormControls()
    }
    
    static toggleFormControls() {
        const form = document.querySelector("#offcanvasSettings");
        
        for (const [key, params] of Object.entries(this.items)) {
            const elem = form.querySelector(
                `[name="settings-${key}"][value="${this.config[key]}"]`,
            )

            if (elem) {
                elem.checked = true
            }
        }
    }
    
    static submitForm() {
        
    }
    
}


//
// export function initialize() {
//     addHandlers();
// }
//
// export function addHandlers() {
//     const reset = document.getElementById('themeReset');
//     if (reset !== null) {
//         reset.addEventListener('click', resetForm);   
//     }
//    
//     const submit = document.getElementById('themeSave');
//     if (submit !== null) {
//         submit.addEventListener('click', submitForm);
//     }
// }
//
// export function removeHandlers() {
//     const reset = document.getElementById('themeReset');
//     reset.removeEventListener('click', resetForm)
//
//     const submit = document.getElementById('themeSave');
//     submit.removeEventListener('click', submitForm)
// }
//
// export function toggleFormControls() {
//     const form = document.getElementById('offcanvasSettings');
//    
//     for (const [key, params] of Object.entries(items)) {
//         const elem = form.querySelector(`[name="settings-${key}"][value="${config[key]}"]`);
//     }
// }
//
// export function submitForm() {
//    
// }
//
// export function resetForm() {
//    
// }