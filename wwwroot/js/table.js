var table;

function exampleLoad(url, arr, controller) {
    console.log("launched");
    var emp = "";
    $(document).ready(function () {
        console.log("ready");

        table = $('#example').DataTable({
            ajax: {
                "url": url,
                "type": "GET",
                "datatype": "json"
            },

            columns: [
                {
                    data: arr[0],
                    "render": function (data, type, row) {
                        return `<a href="/${controller}/details/${row[arr[4]]}">${data}</a>`;
                    }
                },
                {
                    data: arr[1],
                    "render": function (data, type, row) {
                        return `<a href="/${controller}/details/${row[arr[4]]}">${data}</a>`;
                    }
                },
                {
                    data: arr[2],
                    "render": function (data, type, row) {
                        return `<a href="/${controller}/details/${row[arr[4]]}">${data}</a>`;
                    }
                },
                {
                    data: arr[3],
                    "render": function (data, type, row) {
                        return `<a href="/${controller}/details/${row[arr[4]]}">${data || emp}</a>`;
                    }
                },
                {

                    data: arr[4],
                    "render": function (data) {
                        return `<div class="text-center h6 p-0" id="btns">
                            <a href="/${controller}/edit?id=${data}" class="btn btn-primary text-white m-1" style="cursor:pointer; width:100px;">Edit</a>
                            &nbsp;
                            <a class="btn btn-danger text-white m-1" style="cursor:pointer; width:100px;" onclick=Delete('/${controller}/delete?id='+${data})>Delete</a>

                        </div>
                        `
                    }, "width": "30%"
                }
            ],

            "language": {
                "emptyTable": "no data found"
            },
        });
    });

}

console.log($('Hello top'));
console.log($('#dt'));

function Delete(url) {
    swal({
        title: "Are You Sure",
        text: "Once deleted, you will not be able to recover",
        buttons: true,
        icon: "warning",
        danger: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        console.log(table.ajax.reload);
                        table.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}

//function Del(url, controller) {
//    var controller = url.split('/')[1];

//    swal({
//        title: "Are You Sure",
//        text: "Once deleted, you will not be able to recover",
//        buttons: true,
//        icon: "warning",
//        danger: true
//    }).then((willDelete) => {
//        if (willDelete) {
//            $.ajax({
//                type: "DELETE",
//                url: url,
//                success: function (data) {
//                    if (data.success) {
//                        toastr.success(data.message);
                        
//                    }
//                    else {
//                        toastr.error(data.message);
//                    }
//                }
//            });
//        }
//    });
//}
