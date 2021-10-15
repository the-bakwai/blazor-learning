window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "Operation Successful");
    }
    if (type === "error") {
        toastr.error(message, "Operation Failed");
    }
}

window.ShowSwal = (type, message) => {
    if (type === "success") {
        Swal.fire('Success', message, 'success');
    }
    if (type === "error") {
        Swal.fire('Error', message, 'error');
    } 
}