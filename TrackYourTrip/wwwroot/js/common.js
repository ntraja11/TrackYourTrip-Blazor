function ShowConfirmationModal() {
    bootstrap.Modal.getOrCreateInstance(document.getElementById("confirmationModal")).show();
}

function HideConfirmationModal() {
    if (document.activeElement) {
        document.activeElement.blur();
    }
    bootstrap.Modal.getOrCreateInstance(document.getElementById("confirmationModal")).hide()
}