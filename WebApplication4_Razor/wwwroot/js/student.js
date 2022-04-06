var dataTable;
$(document).ready(function () {
    loadDataTable()
})
function loadDataTable() {
    dataTable = $('#tbldata').DataTable({
        "ajax": {
            "url": "api/book",
            "type": "Get",
            "data type": "json"
        },
        "columns": [
            
            { "data": "time", "width": "25%" },
            { "data": "date", "width": "25%" },
            { "data": "availabilitiy", "width": "25%" }
            //{
            //    "data": "id",
            //    "render": function (data) {
            //        return `
            //                <div class="text-center">
            //                 <a class="btn btn-info" href="/booklist/Upsert?id=${data}">Edit</a>
            //                  <a class="btn btn-danger" onclick=Delete("api/book?id=${data}")>Delete</a>
            //                   </div>
            //                           `;
            //    }
            //}
        ]
    })
}
function Delete(url) {
    swal({
        title: "Want To Delete Data ?",
        icon: "warning",
        text: "Delete information !!!",
        dangerModel: true,
        buttons: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                url: url,
                type: "DELETE",
                success: function (data) {
                    if (data.success) {
                        toastr.success(
                            data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}