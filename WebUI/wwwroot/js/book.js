$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    console.log('loadDataTable function called');
    dataTable = $('#tblBook').DataTable({
        "ajax": { url: '/book/getall' },
        "columns": [
            {
                data: 'imageUrl',
                "width": "15%",
                "render": function (data) {
                    if (data !== null) {
                        return `<div>
                                <img src="${data}" style="width:70px; height:50px; border-radius:5px; border:1px solid #ffffff" />
                            </div>`;
                    }
                    else {
                        return `<div>
                                <img src="images\\book\\default.jpg" style="width:70px; height:50px; border-radius:5px; border:1px solid #ffffff" />
                            </div>`;
                    }
                }
            },
            { data: 'name', "width": "15%" },
            { data: 'isbn', "width": "10%" },
            { data: 'authorName', "width": "15%" },
            {
                data: 'isAvailable',
                "width": "10%",
                "render": function (data) {
                    var statusText = data ? 'Available' : 'Borrowed';
                    var statusClass = data ? 'bg-success' : 'bg-danger';

                    return `<span class="d-inline-block ${statusClass} rounded text-white px-2">${statusText}</span>`;
                }
            },
            {
                data: 'borrowedBy',
                "width": "10%",
                "render": function (data) {
                    return data !== null ? data : '-';
                }
            },
            {
                data: 'returnDate',
                "width": "10%",
                "render": function (data) {
                    return data !== null ? new Date(data).toLocaleDateString('en-GB') : '-';
                }
            },
            {
                data: 'id',
                "width": "15%",
                "render": function (data, type, row) {
                    var isBookAvailable = row.returnDate === null;
                    const returnDate = new Date(row.returnDate);
                    const currentDate = new Date();

                    if (isBookAvailable) {
                        return `<div class="w-90 btn-group" role="group">
                                    <a href="/book/lend?id=${data}" class="btn btn-success mx-2 rounded"> <i class="bi bi-arrow-return-right"></i> Lend Book</a>
                                </div>`;
                    }
                    else if (!isBookAvailable && returnDate >= currentDate) {                       
                        return `<div class="w-90 btn-group" role="group">
                                    <a onClick=ReturnBookConfirm('/book/return?id=${data}') class="btn btn-warning mx-2 rounded"> <i class="bi bi-arrow-return-left"></i> Return Book</a>                        
                                </div>`;
                    }

                    else {
                        return `<div class="w-90 btn-group" role="group">
                                    <a onClick=PaymentWarning('/book/return?id=${data}') class="btn btn-danger mx-2 rounded"> <i class="bi bi-arrow-return-left"></i> Return Book</a>
                                </div>`;
                    }                   
                }
            },
        ]
    });
}

function ReturnBookConfirm(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, Return the book!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'GET',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success("Book Successfully Returned");
                }
            })
        }
    })
}

function PaymentWarning(url) {
    Swal.fire({
        title: 'This Book is overdue!',
        text: "Please don't forget to get payment for late return",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Payment Completed, Return the Book'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'GET',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success("Book Successfully Returned");
                }
            })
        }
    })
}