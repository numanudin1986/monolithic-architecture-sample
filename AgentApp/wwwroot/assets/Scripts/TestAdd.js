$(document).ready(function () {
    $("#basic-form").validate({
        rules: {
            LabName: {
                required: true,
                LabName: true
            },
            LabEmail: {
                required: true,
                email: true
            },
            LabPhoneNo: {
                required: true,
                LabPhoneNo: true
            },

            LabAddress: {
                required: true,
                LabPhoneNo: true
            },

            City: {
                required: true,
                LabPhoneNo: true
            },

            ZipCode: {
                required: true,
                LabPhoneNo: true
            },


            State: {
                required: true,
                LabPhoneNo: true
            },

            Fax: {
                required: true,
                LabPhoneNo: true
            },

            MgmtId: {
                required: true,
                LabPhoneNo: true
            },

            LocationId: {
                required: true,
                LabPhoneNo: true
            },

            OrgId: {
                required: true,
                LabPhoneNo: true
            },

        },
        messages: {

            LabName: {
                required: "Lab Name is required"
            },
            LabEmail: {
                required: "Lab Email required",
                email: "The email should be in the format: abc@domain.tld"
            },
            LabPhoneNo: {
                required: "Lab Phone Number is  Required",
            },

            LabPhoneNo: {
                required: "Lab Phone Number is  Required",
            },

            LabPhoneNo: {
                required: "Lab Phone Number is  Required",
            },

            LabPhoneNo: {
                required: "Lab Phone Number is  Required",
            },
            LabPhoneNo: {
                required: "Lab Phone Number is  Required",
            },
            LabPhoneNo: {
                required: "Lab Phone Number is  Required",
            },
            LabPhoneNo: {
                required: "Lab Phone Number is  Required",

            },

            LabPhoneNo: {
                required: "Lab Phone Number is  Required",
            },

            LabPhoneNo: {
                required: "Lab Phone Number is  Required",
            },
        },

        submitHandler: function (form) {
            debugger
            var LabName = $("#LabName").val();
            var LabPhoneNo = $("#LabPhoneNo").val();
            var LabEmail = $("#LabEmail").val();
            showProcessing("btnGet");
            $.ajax({
                type: "POST",
                url: "/Test/TestAjax",
                data: { "LabName": LabName, "LabPhoneNo": LabPhoneNo, "LabEmail": LabEmail },
                success: function (response) {
                    debugger;
                    hideProcessing("btnGet", true, "Data save successfully", "basic-form")
                },
                failure: function (response) {
                    hideProcessing("btnGet", false, "Something went wrong....!")
                },
                error: function (response) {
                    hideProcessing("btnGet", false, "Something went wrong....!")
                }
            });
        }
    });
    //$.validator.addMethod("FamilyIncomes", function (value) {
    //    return /^[0-9]+$/.test(value); // consists of only these chars
    //}, "The Income must be digits only");
    //$.validator.addMethod("ContactNos", function (value) {
    //    return /^[0-9]+$/.test(value); // consists of only these chars
    //}, "The Contact Number must be digits only");
    //$.validator.addMethod("RegNoRegx", function (value) {
    //    return /^[A-Z]{1,1}[-]{1}[0-9]{4}/.test(value); // consists of only these chars Old/* /^[a-zA-Z0-9-_]+$/*/
    //}, "The Registration Number must be alphanumeric and Use T-3232");
    //$.validator.addMethod("PatientName", function (value) {
    //    return (/^[a-zA-Z\s]+$/).test(value); // consists of only these chars
    //}, "The Name can only contain alphabets and spaces");
    //$.validator.addMethod("GuardianOccu", function (value) {
    //    return (/^$|^[a-zA-Z\s]+$/).test(value); // consists of only these chars
    //}, "The Designation can only contain alphabets and spaces");
    //$.validator.addMethod("CNICField", function (value) {
    //    return /^$|^[0-9+]{5}-[0-9+]{7}-[0-9]{1}$/.test(value); // consists of only these chars
    //}, "The CNIC is not in Valid Format. It must be like '11111-1111111-1'");
    //$.validator.addMethod("GeneralValidation", function (value) {
    //    return /^$|^[A-Za-z0-9 _.-]+$/.test(value); // consists of only these chars
    //}, "Only alphanumeric characters are allowed");
    //$.validator.addMethod("ReferenceCodes", function (value) {
    //    return /^$|^[A-Za-z0-9-]+$/.test(value); // consists of only these chars
    //}, "Only alphanumeric characters and - are allowed");
    //$.validator.addMethod("AddressFields", function (value) {
    //    return (/^$|^[A-Za-z0-9.,/\s]+$/).test(value); // consists of only these chars
    //}, "Please write valid address");

    //$.validator.addMethod("LabName", function (value) {
    //    return (/^[a-zA-Z\s]+$/).test(value); // consists of only these chars
    //}, "The name contain only alphabets!");

    //$.validator.addMethod("LabName", function (value) {
    //    return (/^[a-zA-Z\s]+$/).test(value); // consists of only these chars
    //},
    $.validator.addMethod("LabName", function (value) {
        return (/^[a-zA-Z\s]+$/).test(value); // consists of only these chars
    }, "The Name can only contain alphabets and spaces");
    $.validator.addMethod("LabPhoneNo", function (value) {
        return /^[0-9]+$/.test(value); // consists of only these chars
    }, "The Contact Number must be digits only");
    function clearForm() {

    }

});




