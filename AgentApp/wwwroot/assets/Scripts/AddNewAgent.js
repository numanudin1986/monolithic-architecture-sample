var _hfEncryptAgentId = $("#hfEncryptAgentId").val();
var _thisForm = "addAgentForm";
var _thisFormSaveButtonId = "btnSaveAgent";
$(document).ready(function () {
    debugger;
    $('#PhoneNo').mask('(999) 999-9999');

    $("#" + _thisForm).validate({
        messages: {
            AgentName: {
                required: "Agent Name is required!"
            },
            WorkingArea: {
                required: "Working Area is required!"

            },
            Commission: {
                required: "Commission is required!"
            }
        },
        rules: {
            AgentName: {
                required: true
            },
            WorkingArea: {
                required: true
            },
            Commission: {
                required: true
            }
        },
        submitHandler: function () {
            debugger;
            let _objAddAgent = {
                EncryptedAgentId: _hfEncryptAgentId,
                AgentName: $("#AgentName").val(),
                WorkingArea: $("#WorkingArea").val(),
                Commission: $("#Commission").val(),
                PhoneNo: $("#PhoneNo").val(),
                Country: $("#Country").val(),
            };
            showProcessing(_thisFormSaveButtonId);
            $.ajax({
                type: "POST",
                url: "/Agent/AddAgent",
                data: _objAddAgent,
                success: function (res) {
                    debugger;
                    hideProcessing(_thisFormSaveButtonId, (res.statusCode == 200 ? true : false), res.statusMessage, _thisForm)
                    debugger;
                    window.location.href = "/Agent/Index";

                },
                failure: function (error) {
                    debugger
                    hideProcessing(_thisFormSaveButtonId, false, "Something went wrong, please contact support team!");
                },
                error: function (error) {
                    debugger
                    hideProcessing(_thisFormSaveButtonId, false, "Something went wrong, please contact support team!");
                }
            });
        }
    });
});

