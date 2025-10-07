$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblBorrower').DataTable({
        "ajax": { url: '/borrower/borrowerList' },
        "columns": [
            { data: 'id', "width": "35%" },
            { data: 'name', "width": "35%" },
            { data: 'libraryBorrowerId', "width": "20%" },
            {
                data: 'id',
                "width": "10%",
                "render": function (data, type, row) {

                    return `<div class="btn-group" role="group">
                                <a onClick=DeleteBorrowerConfirm('/borrower/delete?id=${data}') class="btn btn-danger mx-2 rounded" style="width: 100px;"> 
                                <i class="bi bi-trash-fill"></i></a>                        
                            </div>`;
                }
            }
        ]
    });
}

function DeleteBorrowerConfirm(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, Delete the borrower!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (result) {
                    dataTable.ajax.reload();

                    if (result.serviceResponse) {
                        toastr.success(result.message)
                    } else {
                        toastr.error(result.message)
                    }
                },
                error: function (error) {
                    if (error.status === 500) {
                        toastr.error('An internal server error occurred.');
                        $('#createBorrowerModal').modal('hide');
                    }
                }
            })
        }
    })
}