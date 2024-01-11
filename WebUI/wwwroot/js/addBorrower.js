
$(document).ready(function () {
    $("#submitBtn").click(function () {
        var name = $("#name").val();
        var libraryBorrowerId = $("#libraryBorrowerId").val();

        if (name.trim() === "") {
            $("#nameValidation").text("Name is required.");
            return;
        }

        $.ajax({
            type: "POST",
            url: "/Borrower/Add",
            data: JSON.stringify({
                name: name,
                libraryBorrowerId: libraryBorrowerId
            }),
            contentType: "application/json; charset=utf-8",
            success: function (result) {

                $('#createBorrowerModal').modal('hide');

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
        });
    });
});

