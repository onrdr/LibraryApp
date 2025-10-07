
$(document).ready(function () {

    // When modal is shown, generate a new ID
    $('#createBorrowerModal').on('show.bs.modal', function () {
        const newId = generateLibraryBorrowerId();
        $("#libraryBorrowerId").val(newId);
    });

    // Function to generate a simple unique borrower ID
    function generateLibraryBorrowerId() {
        const prefix = "L-";
        const randomPart = Math.floor(100000 + Math.random() * 900000); // 6 digits
        return prefix + randomPart;
    }

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
                location.reload();

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
                    location.reload();
                }
            },
            finally: function () {
                location.reload();
            }
        });
    });
});

