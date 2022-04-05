﻿$(document).ready(function () {
    alert("UserRecords JQuery is Running Fine");
    UserDataTableFill("", "");

    $(document).on('click', '.EditRecordCLS', function () {
        alert("hello");
        UserDataTableFill($(this).attr('data-UserIdEdit').trim(), "where Id=");
    });

    $("#FirstNameSortingLink").click(function () {
        UserDataTableFill("order by FirstName", "");
    });
    $("#LastNameSortingLink").click(function () {
        UserDataTableFill("order by LastName", "");
    });
    $("#EmailIdSortingLink").click(function () {
        UserDataTableFill("order by EmailId", "");
    });
    $("#GenderSortingLink").click(function () {
        UserDataTableFill("order by Gender", "");
    });
    $("#TxtFNameSearch").keyup(function () {
        UserDataTableFill("", "where FirstName like'%" + $(this).val().trim() + "%'");
    });

    $("#TxtLNameSearch").keyup(function () {
        UserDataTableFill("", "where LastName like'%" + $(this).val().trim() + "%'");
    });

    $("#TxtContactNoSearch").keyup(function () {
        UserDataTableFill("", "where ContactNo like'%" + $(this).val().trim() + "%'");
    });

    $("#TxtEmailIdSearch").keyup(function () {
        UserDataTableFill("", "where EmailId like'%" + $(this).val().trim() + "%'");
    });
    $("#DDL_PageCounter").change(function () {
        UserDataTableFill("", "");
    });



    $(document).on('click', '.StatusClass', function () {
        if (confirm("are you sure want to channge the status??")) {
            if ($(this).attr('data-UserStatus') == "N") {
                $(this).find("i").removeClass("fa-times-circles");
                $(this).find("i").addClass("fa-check-square");
                $(this).find("i").css("color", "#228B22");
                $(this).attr("data-UserStatus", "Y");
                UpdateUserStatus(parseInt($(this).attr('data-UserIdStatus')), "Y");
            }
            else {
                $(this).find("i").removeClass("fa-check-square");
                $(this).find("i").addClass("fa-times-circle");
                $(this).find("i").css("color", "#ff0000");
                $(this).attr("data-UserStatus", "N");
                UpdateUserStatus(parseInt($(this).attr('data-UserIdStatus')), "N");
            }
        }

    });
    var $FNameLNameRegEx = /^([a-zA-Z]{2,20})$/;
    var $EmailIdRegEx = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{2,10})(\]?)$/;
    var $ConNoRegEx = /^([0-9]{10})$/;

    var TxtFNameFlag = false, TxtLNameFlag = false, TxtEmailIdFlag = false, TxtContactNoFlag = false;


    var specialKeys = new Array();
    $("#TxtFName").bind("keypress", function (e) {
        var keyCode = e.which ? e.which : e.keyCode
        var ret = ((keyCode >= 65 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 122) || specialKeys.indexOf(keyCode) != -1);
        $("#TxtFNameValidate").html(ret ? "" : "(*) Invalid Input..!!");
        return ret;
    });

    $("#TxtFName").bind("blur", function (e) {
        if ($("#TxtFName").val() == "") {
            TxtFNameFlag = false;
            $("#TxtFNameValidate").empty();
            $("#TxtFNameValidate").html('(*) First Name Required..!!');
        }
        else {
            $("#TxtFNameValidate").empty();
            if (!$("#TxtFName").val().match($FNameLNameRegEx)) {
                $("#TxtFNameValidate").html('Invalid First Name..!!');
                TxtFNameFlag = false;
            }
            else {
                $("#TxtFNameValidate").empty();
                TxtFNameFlag = true;
            }
        }
    });


    $("#TxtLName").bind("keypress", function (e) {
        var keyCode = e.which ? e.which : e.keyCode
        var ret = ((keyCode >= 65 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 122) || specialKeys.indexOf(keyCode) != -1);
        $("#TxtLNameValidate").html(ret ? "" : "(*) Invalid Input..!!");
        return ret;
    });

    $("#TxtLName").bind("blur", function (e) {
        if ($("#TxtLName").val() == "") {
            TxtLNameFlag = false;
            $("#TxtLNameValidate").empty();
            $("#TxtLNameValidate").html('(*) Last Name Required..!!');
        }
        else {
            $("#TxtLNameValidate").empty();
            if (!$("#TxtLName").val().match($FNameLNameRegEx)) {
                $("#TxtLNameValidate").html('Invalid Last Name..!!');
                TxtLNameFlag = false;
            }
            else {
                $("#TxtLNameValidate").empty();
                TxtLNameFlag = true;
            }
        }
    });


    $("#TxtContactNo").bind("keypress", function (e) {
        var keyCode = e.which ? e.which : e.keyCode
        var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
        $("#TxtContactNoValidate").html(ret ? "" : "(*) Invalid Input..!!");
        return ret;
    });

    $("#TxtContactNo").bind("blur", function (e) {
        $("#TxtContactNoValidate").empty();
        if ($("#TxtContactNo").val() == '') {
            TxtContactNoFlag = false;
            $("#TxtContactNoValidate").html('(*) Contact No Required..!!');
        }
        else {
            if (!$("#TxtContactNo").val().match($ConNoRegEx)) {
                TxtContactNoFlag = false;
                $("#TxtContactNoValidate").html('Invalid Contact No..!!');
            }
            else {
                $("#TxtContactNoValidate").empty();
                TxtContactNoFlag = true;
            }
        }
        return TxtContactNoFlag;
    });

    $("#TxtEmailId").bind("blur", function (e) {
        $("#TxtEmailIdValidate").empty();
        if ($("#TxtEmailId").val() == "") {
            $("#TxtEmailIdValidate").empty();
            TxtEmailIdFlag = false;
            $("#TxtEmailIdValidate").html('(*) Email Id Required..!!');
        }
        else {
            if (!$("#TxtEmailId").val().match($EmailIdRegEx)) {
                TxtEmailIdFlag = false;
                $("#TxtEmailIdValidate").html('Invalid Email Id..!!');
            }
            else {
                $("#TxtEmailIdValidate").empty();
                TxtEmailIdFlag = true;
            }
        }
        return TxtEmailIdFlag;
    });

    $("#BtnUpdateRecord").click(function () {
        if ($("#TxtFName").val() == "")
        {
            $("#TxtFNameValidate").empty();
            $("#TxtFNameValidate").html('(*) First Name Required..!!');
        }
        else
        {
            $("#TxtFNameValidate").empty();
            if (!$("#TxtFName").val().match($FNameLNameRegEx))
            {
                $("#TxtFNameValidate").html('Invalid First Name..!!');
                TxtFNameFlag = false;
            }
            else {
                $("#TxtFNameValidate").empty();
                TxtFNameFlag = true;
            }
        }
        if ($("#TxtLName").val() == "")
        {
            $("#TxtLNameValidate").empty();
            $("#TxtLNameValidate").html('(*) Last Name Required..!!');
        }
        else {
            $("#TxtLNameValidate").empty();
            if (!$("#TxtLName").val().match($FNameLNameRegEx)) {
                $("#TxtLNameValidate").html('Invalid Last Name..!!');
                TxtLNameFlag = false;
            }
            else {
                $("#TxtLNameValidate").empty();
                TxtLNameFlag = true;
            }
        }
        if ($("#TxtContactNo").val() == "") {
            $("#TxtContactNoValidate").empty();
            $("#TxtContactNoValidate").html('(*) Contact No. Required..!!');
        }
        else {
            $("#TxtContactNoValidate").empty();
            if (!$("#TxtContactNo").val().match($ConNoRegEx)) {
                $("#TxtContactNoValidate").html('Invalid Contact No..!!');
                TxtContactNoFlag = false;
            }
            else {
                $("#TxtContactNoValidate").empty();
                TxtContactNoFlag = true;
            }
        }
        if ($("#TxtEmailId").val() == "") {
            $("#TxtEmailIdValidate").empty();
            $("#TxtEmailIdValidate").html('(*) Email Id Required..!!');
        }
        else {
            $("#TxtEmailIdValidate").empty();
            if (!$("#TxtEmailId").val().match($EmailIdRegEx)) {
                TxtEmailIdFlag = false;
                $("#TxtEmailIdValidate").html('Invalid Email Id..!!');
            }
            else {
                $("#TxtEmailIdValidate").empty();
                TxtEmailIdFlag = true;
            }
        }

        if (TxtFNameFlag == true && TxtLNameFlag == true && TxtEmailIdFlag == true && TxtContactNoFlag == true) {
            UpdateRecord();

        }
        else {
            alert("Invalid Inputs..!!")
        }
    });

});

function UserDataTableFill(orderby, whereclause) {
    alert("ajax is calling");
    $.ajax({
        type: "GET",
        url: "/Home/GetAllUserData",
        data: { "orderby": orderby, "whereclause": whereclause },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert("Get ALL USER DATA DONE");
            var UserArr = response.data;
            if (UserArr.length > 0) {
                if (whereclause == "where Id=") {
                    $("#TxtFName").val(UserArr[0].FirstName);
                    $("#TxtLName").val(UserArr[0].LastName);
                    $("#TxtContactNo").val(UserArr[0].ContactNo);
                    $("#TxtEmailId").val(UserArr[0].EmailId);
                    $("#DDL_Gender").val(UserArr[0].Gender);
                    $("#BtnUpdateRecord").attr('EditUserId', UserArr[0].Id);

                }
                else {


                    $("#UserTableBody").empty();
                    for (var i = 0; i < UserArr.length; i++) {
                        var j = i + 1;
                        var StatusIcon = null;
                        var GenderIcon = null;
                        if (UserArr[i].Status == 'Y') {
                            StatusIcon = "<i style='color:#228B22' class='fa fa-2x fa-check-square'></i>";
                        }
                        else {
                            StatusIcon = "<i style='color:#ff0000' class='fa fa-2x fa-times-circle'></i>";
                        }
                        if (UserArr[i].Gender == 'M') {
                            GenderIcon = "<i style='color:#0000FF' class='fa fa-2x fa-male'></i>";
                        }
                        else {
                            GenderIcon = "<i style='color:rgba(255,0,0,0.6)' class='fa fa-2x fa-female'></i>";
                        }
                        var DataRowId = parseInt(i / parseInt($("#DDL_PageCounter").val())) + 1;
                        $("#UserTableBody").append(
                            "<tr data-row-id='" + DataRowId + "'>"
                            + "<td>" + j + "</td>"
                            + "<td>" + UserArr[i].FirstName + "</td>"
                            + "<td>" + UserArr[i].LastName + "</td>"
                            + "<td>" + UserArr[i].ContactNo + "</td>"
                            + "<td>" + UserArr[i].EmailId + "</td>"
                            + "<td class='text-center'>" + GenderIcon + "</td>"
                            /* + "<td class='text-center'><a data-UserIdEdit=" + UserArr[i].Id + " class='EditRecordCLS' data-toggle='modal' data-target='#EditUserRecord'><i class='fa fa-2x fa-edit'></i></a></td>"*/
                            + "<td class='text-center'><a data-UserIdEdit=" + UserArr[i].Id + " class='EditRecordCLS' data-toggle='modal' data-target='#EditUserRecord'><i class='fa fa-2x fa-edit'></i></a></td>"
                            + "<td class='text-center'><a data-UserIdStatus=" + UserArr[i].Id + " data-UserStatus=" + UserArr[i].Status + " class='StatusClass'>" + StatusIcon + "</a></td>"
                            + "</tr>"
                        );
                        $('#UserTableBody tr').css("display", "none");
                        $("[data-row-id=1]").css("display", "table-row");

                        var MaxPagerCounter = parseInt(UserArr.length / parseInt($("#DDL_PageCounter").val()));
                        var MaxPagerCounterMod = parseInt(UserArr.length % parseInt($("#DDL_PageCounter").val()));

                        if (MaxPagerCounter <= 1 && (MaxPagerCounterMod == 0) || (UserArr.length) < ($("#DDL_PageCounter").val())) {
                            $("#ManagePager").css("visibility", "hidden");
                        }
                        else {
                            $("#ManagePager").css("visibility", "visible");
                            $("#ManagePager").empty();
                            $("#ManagePager").append("<li class='page-item' data-indexid='-1'><a class='page-link'><i class='fa fa-angle-double-left'></i> Previous</a></li> <li class='page-item active' data-indexid='1'><a class='page-link'>1</a></li>");

                            if (MaxPagerCounterMod > 0) {
                                MaxPagerCounter += 1;
                            }
                            if ((MaxPagerCounter > 1) && i == parseInt(UserArr.length - 1)) {
                                for (var CounterPager = 0; CounterPager < MaxPagerCounter - 1; CounterPager++) {
                                    var finalCounter = parseInt(CounterPager + 2);
                                    $("#ManagePager").append("<li class= 'page-item' data-indexid=" + finalCounter + " ><a class=page-link>" + finalCounter + "</a></li>");
                                }
                            }
                        }

                    } $("#ManagePager").append("<li class='page-item' data-indexid='0'><a class='page-link'>Next <i class='fa fa-angle-double-right'></i></a></li>");

                }



            }

            else {
                $("#UserTableBody").append(
                    "<tr>"
                    + "<td colspan='8' class='text-center text-danger'>-- No Records Found -- </td>"
                    + "</tr>"
                );
            }

        },
        error: function () {
            alert("UnExpected error occured sorry for inconvinience!!!");
        }

    });
}

//function UpdateRecord()
//{
//    alert("UpdateRecord method called.");
//    $.ajax({
//        type: "POST",
//        url: "/Home/CreateNewAccount",
//      //data: '{Id:' + parseInt($("#BtnUpdateRecord").attr('data-UserIdEdit')) + ',FirstName: "' + $("#TxtFName").val().trim() + '",LastName: "' + $("#TxtLName").val().trim() + '",ContactNo: "' + $("#TxtContactNo").val().trim() + '",EmailId: "' + $("#TxtEmailId").val().trim() + '",Password: "",Gender: "' + $("#DDL_Gender").val() + '" }',
//        data: '{Id:' + parseInt($("#BtnUpdateRecord").attr('data-UserIdEdit')) + ',FirstName: "' + $("#TxtFName").val().trim() + '",LastName: "' + $("#TxtLName").val().trim() + '",ContactNo: "' + $("#TxtContactNo").val().trim() + '",EmailId: "' + $("#TxtEmailId").val().trim() + '",Password: "",Gender: "' + $("#DDL_Gender").val() + '" }',
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function (response) {
//            if (response.Success == "Success") {
//                alert("Record Updated Successfully..!!");
//                $("input").val('');
//                $("#DDL_Gender").val('M');
//                UserDataTableFill("", "");
//                $("#EditUserRecord .close").click();
//            }
//        },
//        error: function () {
//            alert("Unexpected Error Sorry For The Inconvinience..!!");
//        }
//    });
//}


function UpdateRecord() {
    $.ajax({
        type: "POST",
        url: "/Home/CreateNewAccount",
        data: '{Id:' + parseInt($("#BtnUpdateRecord").attr('data-UserIdEdit')) + ',FirstName: "' + $("#TxtFName").val().trim() + '",LastName: "' + $("#TxtLName").val().trim() + '",ContactNo: "' + $("#TxtContactNo").val().trim() + '",EmailId: "' + $("#TxtEmailId").val().trim() + '",Password: "",Gender: "' + $("#DDL_Gender").val() + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.Success == "Success") {
                alert("Record Updated Successfully..!!");
                $("input").val('');
                $("#DDL_Gender").val('M');
                UserDataTableFill("", "");
                $("#EditUserRecord .close").click();
            }
        },
        error: function () {
            alert("Unexpected Error Sorry For The Inconvinience..!!");
        }
    });
}


function UpdateUserStatus(Id, Status) {
    alert("UpdateUserSatatus calling");
    $.ajax({ //Declaration of ajax function using ajax keyword
        url: "/Home/UpdateUserStatus", //passsing the name of get or post method
        type: 'POST', //assigning type post or get
        cache: false, //cache true or false
        data: { Id: Id, Status: Status }, //value and keyvalues
        success: function () { //if successfully post or get is executed

        },
        error: function (jqXHR, textStatus, err) { //if there is error
            alert('text status ' + textStatus + ', err ' + err) //prints error message
        }
    });

    return true;
}
