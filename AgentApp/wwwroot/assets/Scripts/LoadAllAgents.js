
var _LoadAllAgenttableId = "tblLoadAllAgent";
$(document).ready(function () {
    LoadAllAgents();
});

function LoadAllAgents() {
    var dataTable = $("#" + _LoadAllAgenttableId).DataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url": "/Agent/LoadAgentData",
            "type": "POST",
            "datatype": "json"
        },
        "columns": [

            { "data": "id", "name": "id", "autoWidth": true },
            { "data": "agentName", "name": "agentName", "autoWidth": true },
            { "data": "workingArea", "workingArea": "type", "autoWidth": true },
            { "data": "commission", "name": "commission", "autoWidth": true },
            { "data": "phoneNo", "name": "phoneNo", "autoWidth": true },
            { "data": "country", "name": "country", "autoWidth": true },
            { "data": "edit", "name": "country", "autoWidth": true },
            { "data": "delete", "name": "country", "autoWidth": true }


        ],
        "columnDefs": [{
            "targets": [0],
            "visible": false,
            "searchable": false
        },
        {
            //"targets": [7,8],
            //"orderable": false,
            //"searchable": false
        }],
        "initComplete": function (settings, json) {
        }
    });
    $('#tblLoadAllAgent_filter').html('<div class="form-group pull-right"><a style="color:white;" id="btnSearchTable" class="btn btn-success"><i class="fa fa-search"></i> <span>Search</span></a><a style="color:white;" id="btnResetTable" class="btn btn-primary"><i class="fa fa-refresh"></i> <span>Reset</span></a></div>');
    function clearTable() {
        $('#AgentName').val("");
        $('#WokingArea').val("");
        $('#Commission').val("");
        $('#PhoneNo').val("");
        $('#Country').val("");
    }


    //-----------------------------------*( CLICK EVENTS )*-------------------------------



    $('#btnSearchTable').on('click', function (e) {
        debugger;
        let _json = JSON.stringify({
            AgentName: $('#AgentName').val(),
            WorkingArea: $('#WokingArea').val(),
            Commission: $('#Commission').val(),
            PhoneNo: $('#PhoneNo').val(),
            Country: $('#Country').val(),

        });
        dataTable.columns(0).search(_json).draw();
    });

    $('#btnResetTable').on('click', function () {
        clearTable();
        dataTable.search('').columns().search('').draw();
    });

    $(document).on("click", ".btnEdit", function () {
        debugger;
        let _tr = $(this).closest('tr');
        let _thisRowData = $("#" + _LoadAllAgenttableId).dataTable().fnGetData(_tr);
    });

    $(document).on("click", ".js-sweetalert", function () {
        debugger;
        let _tr = $(this).closest('tr');
        let _thisRowData = $("#" + _LoadAllAgenttableId).dataTable().fnGetData(_tr);

        let _objDeleteAgent = {
            Id: _thisRowData.id,
            AgentName: _thisRowData.agentName,
            WorkingArea: _thisRowData.workingArea,
            Commission: _thisRowData.commission,
            PhoneNo: _thisRowData.phoneNo,
            Country: _thisRowData.country,
        };
        var type = $(this).data('type');

        if (type === 'confirm') {
            showConfirmMessage(_objDeleteAgent);
        }
    });
    function showConfirmMessage(objDeleteAgent) {
        swal({
            title: "Are you sure?",
            text: "You will not be able to recover this Agent!",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#dc3545",
            confirmButtonText: "Yes, delete it!",
            closeOnConfirm: false
        }, function () {
            debugger;

            $.ajax({
                type: "POST",
                url: "/Agent/DeleteAgent",
                data: objDeleteAgent,
                success: function (res) {
                    $("#btnResetTable").trigger('click')
                    swal("Deleted!", res.statusMessage, "success");
                },
                failure: function () {
                    hideProcessing('', false, "Something went wrong, please contact support team!");
                },
                error: function () {
                    hideProcessing('', false, "Something went wrong, please contact support team!");
                }
            });
        });
    }
}




