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
                "width": "10%",
                "render": function (data) {
                    var defaultImage = "images\\book\\default.jpg";
                    if (data !== null) {
                        return `<div>
                                <img src="${data}" style="width:70px; height:50px; border-radius:5px; border:1px solid #ffffff" />
                            </div>`;
                    }
                    else {
                        return `<div>
                                <img src="${defaultImage}" style="width:70px; height:50px; border-radius:5px; border:1px solid #ffffff" />
                            </div>`;
                    }
                }
            },
            { data: 'name', "width": "15%" },
            { data: 'authorName', "width": "15%" },
            { data: 'isbn', "width": "10%" },
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
                "width": "12%",
                "render": function (data) {
                    return data !== null ? data : '-';
                }
            },
            {
                data: 'libraryBorrowerId',
                "width": "8%",
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
                "width": "10%",
                "render": function (data, type, row) {
                    var isBookAvailable = row.returnDate === null;
                    const returnDate = new Date(row.returnDate);
                    const currentDate = new Date();

                    if (isBookAvailable) {
                        return `<div class="btn-group" role="group">
                                    <a href="/book/lend?id=${data}" class="btn btn-success mx-2 rounded" style="width: 100px;"> <i class="bi bi-arrow-return-right"></i> Lend</a>
                                </div>`;
                    } else if (!isBookAvailable && returnDate >= currentDate) {
                        return `<div class="btn-group" role="group">
                                    <a onClick=ReturnBookConfirm('/book/return?id=${data}') class="btn btn-warning mx-2 rounded" style="width: 100px;"> <i class="bi bi-arrow-return-left"></i> Return</a>                        
                                </div>`;
                    } else {
                        return `<div class="btn-group" role="group">
                                    <a onClick=PaymentWarning('/book/return?id=${data}') class="btn btn-danger mx-2 rounded" style="width: 100px;"> <i class="bi bi-arrow-return-left"></i> Return</a>
                                </div>`;
                    }                  
                }
            }
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