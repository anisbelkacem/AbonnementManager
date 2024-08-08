var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": '/abonnement/getall',
            "dataSrc": function (json) {
                console.log(json.data);  // Log the data to the console
                return json.data;
            }
        },
        "columns": [
            { "data": "description", "width": "15%" },
            { "data": "client.name", "width": "15%" },
            { "data": "application.name", "width": "15%" },
            { "data": "dateDebut", "width": "10%" },
            { "data": "dateFin", "width": "10%" },
            {
                "data": "dateFin",
                "render": function (data) {
                    var currentDate = new Date();
                    var endDate = new Date(data);
                    if (endDate >= currentDate) {
                        return '<span class="badge bg-success">Active</span>';
                    } else {
                        return '<span class="badge bg-danger">Expired</span>';
                    }
                },
                "width": "10%"
            },
            {
                "data": "id_Abon",
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                     <a href="/abonnement/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Edit</a>               
                     <a onClick=Delete('/abonnement/delete/${data}') class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
                    </div>`
                },
                "width": "25%"
            }
        ],
        
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    })
}