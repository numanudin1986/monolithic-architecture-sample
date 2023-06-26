
$(document).ready(function () {
    debugger
    LoadData();
});

function LoadData() {
    var dataTable =  $("#userTable").DataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url": "/Test/LoadTestAjaxDataTable",
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs": [{
            "targets": [0],
            "visible": false,
            "searchable": false
        }],
        "columns": [
            
            { "data": "labId", "name": "labId", "autoWidth": true },
            { "data": "labName", "name": "labName", "autoWidth": true },
            { "data": "labPhoneNo", "name": "labPhoneNo", "autoWidth": true }
        ],
        "initComplete": function (settings, json) {
            debugger;
           // $('div.loading').remove();
        }
    });
    $('#userTable_filter').html('<div class="form-group pull-right"><a id="btnSearchTable" class="btn btn-success">Search</a><a id="btnResetTable" class="btn btn-primary">Reset</a></div>');
    $('#btnSearchTable').on('click', function (e) {
        debugger;
        var LabName =    $('#LabName').val();
        var LabPhoneNo = $('#LabPhoneNo').val();
        var dataa = {
            LabName: LabName,
            LabPhoneNo: LabPhoneNo
        };
        var json = JSON.stringify(dataa);
        dataTable.columns(0).search(json).draw();
    });

    $('#btnResetTable').on('click', function () {
        debugger;
        clearTable();
        dataTable.search('').columns().search('').draw();
    });

    function clearTable() {
        $('#LabName').val("");
        $('#LabPhoneNo').val("");
    }
}



