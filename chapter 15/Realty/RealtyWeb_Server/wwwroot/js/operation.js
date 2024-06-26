﻿const notyf = new Notyf({
    duration: 5000,
    position: {
        x: 'right',
        y: 'top',
    },
    dismissible: true
});

window.DisplayNotyf = (type, message) => {
    if (type === "success") {
        notyf.success('<b>Успех</b><br>' + message);
    }
    if (type === "error") {
        notyf.error('<b>Неудача</b><br>' + message);
    }
}

window.ShowSweetAlert = (type, message) => {
    if (type === "success") {
        Swal.fire(
            'Уведомление об успехе!',
            message,
            'success'
        )
    }
    if (type === "error") {
        Swal.fire(
            'Уведомление об ошибке!',
            message,
            'error'
        )
    }
}

function ShowRemoveConfirmationModal() {
    $('#removeConfirmationModal').modal('show');
}

function HideRemoveConfirmationModal() {
    $('#removeConfirmationModal').modal('hide');
}