﻿////$(document).ready(function () {
////    alert("hello");
////    //Global Variable Declaration.

////    var $FNameLNameRegEx = /^([a-zA-Z]{2,20})$/;
////    var $PasswordRegEx = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z]{8,12}$/;
////    var $EmailIdRegEx = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{2,10})(\]?)$/;
////    var $ConNoRegEx = /^([0-9]{10})$/;

////    var TxtFNameFlag = false, TxtLNameFlag = false, TxtEmailIdFlag = false, TxtContactNoFlag = false, TxtPasswordFlag = false;

////    $("#TxtFName").bind("keypress", function (e) {
////        var keyCode = e.which ? e.which : e.keyCode
////        var ret = ((keyCode >= 65 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 122) || specialKeys.indexOf(keyCode) != -1);
////        $("#TxtFNameValidate").html(ret ? "" : "(*) Invalid Input..!!");
////        return ret;
////    });

////    $("#TxtFName").bind("blur", function (e) {
////        if ($("#TxtFName").val() == "") {
////            TxtFNameFlag = false;
////            $("#TxtFNameValidate").empty();
////            $("#TxtFNameValidate").html('(*) First Name Required..!!');
////        }
////        else {
////            $("#TxtFNameValidate").empty();
////            if (!$("#TxtFName").val().match($FNameLNameRegEx)) {
////                $("#TxtFNameValidate").html('Invalid First Name..!!');
////                TxtFNameFlag = false;
////            }
////            else {
////                $("#TxtFNameValidate").empty();
////                TxtFNameFlag = true;
////            }
////        }
////    });


////    $("#TxtLName").bind("keypress", function (e) {
////        var keyCode = e.which ? e.which : e.keyCode
////        var ret = ((keyCode >= 65 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 122) || specialKeys.indexOf(keyCode) != -1);
////        $("#TxtLNameValidate").html(ret ? "" : "(*) Invalid Input..!!");
////        return ret;
////    });

////    $("#TxtLName").bind("blur", function (e) {
////        if ($("#TxtLName").val() == "") {
////            TxtLNameFlag = false;
////            $("#TxtLNameValidate").empty();
////            $("#TxtLNameValidate").html('(*) Last Name Required..!!');
////        }
////        else {
////            $("#TxtLNameValidate").empty();
////            if (!$("#TxtLName").val().match($FNameLNameRegEx)) {
////                $("#TxtLNameValidate").html('Invalid Last Name..!!');
////                TxtLNameFlag = false;
////            }
////            else {
////                $("#TxtLNameValidate").empty();
////                TxtLNameFlag = true;
////            }
////        }
////    });


////    $("#TxtContactNo").bind("keypress", function (e) {
////        var keyCode = e.which ? e.which : e.keyCode
////        var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
////        $("#TxtContactNoValidate").html(ret ? "" : "(*) Invalid Input..!!");
////        return ret;
////    });

////    $("#TxtContactNo").bind("blur", function (e) {
////        $("#TxtContactNoValidate").empty();
////        if ($("#TxtContactNo").val() == '') {
////            TxtContactNoFlag = false;
////            $("#TxtContactNoValidate").html('(*) Contact No Required..!!');
////        }
////        else {
////            if (!$("#TxtContactNo").val().match($ConNoRegEx)) {
////                TxtContactNoFlag = false;
////                $("#TxtContactNoValidate").html('Invalid Contact No..!!');
////            }
////            else {
////                $("#TxtContactNoValidate").empty();
////                TxtContactNoFlag = true;
////            }
////        }
////        return TxtContactNoFlag;
////    });

////    $("#TxtEmailId").bind("blur", function (e) {
////        $("#TxtEmailIdValidate").empty();
////        if ($("#TxtEmailId").val() == "") {
////            $("#TxtEmailIdValidate").empty();
////            TxtEmailIdFlag = false;
////            $("#TxtEmailIdValidate").html('(*) Email Id Required..!!');
////        }
////        else {
////            if (!$("#TxtEmailId").val().match($EmailIdRegEx)) {
////                TxtEmailIdFlag = false;
////                $("#TxtEmailIdValidate").html('Invalid Email Id..!!');
////            }
////            else {
////                $("#TxtEmailIdValidate").empty();
////                TxtEmailIdFlag = true;
////            }
////        }
////        return TxtEmailIdFlag;
////    });

////    $("#TxtPassword").bind("blur", function (e) {
////        $("#TxtPasswordValidate").empty();
////        if ($("#TxtPassword").val() == "") {
////            $("#TxtPasswordValidate").html("(*) Password Required..!!");
////            TxtPasswordFlag = false;
////        }
////        else {
////            if (!$("#TxtPassword").val().match($PasswordRegEx)) {
////                TxtPasswordFlag = false;
////                $("#TxtPasswordValidate").html('-- Invalid Password..!!<br/><ul style="padding:20px;"><li> Minimum 8 Maximum 12 Character Required.</li><li> Atleast One Uppercase Required.</li><li> Atleast One Lowercase Required.</li><li> Atleast One Numeric Required.</li><li> NO SPECIAL CHARACTERS ALLOWED.</li></ul>');
////            }
////            else {
////                $("#TxtPasswordValidate").empty();
////                TxtPasswordFlag = true;
////            }
////        }
////        return TxtPasswordFlag;
////    });

////    $("#BtnSignUp").click(function () {
////        if ($("#TxtFName").val() == "") {
////            $("#TxtFNameValidate").empty();
////            $("#TxtFNameValidate").html('(*) First Name Required..!!');
////        }
////        else {
////            $("#TxtFNameValidate").empty();
////            if (!$("#TxtFName").val().match($FNameLNameRegEx)) {
////                $("#TxtFNameValidate").html('Invalid First Name..!!');
////                TxtFNameFlag = false;
////            }
////            else {
////                $("#TxtFNameValidate").empty();
////                TxtFNameFlag = true;
               
////            }
////        }
////        if ($("#TxtLName").val() == "") {
////            $("#TxtLNameValidate").empty();
////            $("#TxtLNameValidate").html('(*) Last Name Required..!!');
////        }
////        else {
////            $("#TxtLNameValidate").empty();
////            if (!$("#TxtLName").val().match($FNameLNameRegEx)) {
////                $("#TxtLNameValidate").html('Invalid Last Name..!!');
////                TxtLNameFlag = false;
////            }
////            else {
////                $("#TxtLNameValidate").empty();
////                TxtLNameFlag = true;
////            }
////        }
////        if ($("#TxtContactNo").val() == "") {
////            $("#TxtContactNoValidate").empty();
////            $("#TxtContactNoValidate").html('(*) Contact No. Required..!!');
////        }
////        else {
////            $("#TxtContactNoValidate").empty();
////            if (!$("#TxtContactNo").val().match($ConNoRegEx)) {
////                $("#TxtContactNoValidate").html('Invalid Contact No..!!');
////                TxtContactNoFlag = false;
////            }
////            else {
////                $("#TxtContactNoValidate").empty();
////                TxtContactNoFlag = true;
////            }
////        }
////        if ($("#TxtEmailId").val() == "") {
////            $("#TxtEmailIdValidate").empty();
////            $("#TxtEmailIdValidate").html('(*) Email Id Required..!!');
////        }
////        else {
////            $("#TxtEmailIdValidate").empty();
////            if (!$("#TxtEmailId").val().match($EmailIdRegEx)) {
////                TxtEmailIdFlag = false;
////                $("#TxtEmailIdValidate").html('Invalid Email Id..!!');
////            }
////            else {
////                $("#TxtEmailIdValidate").empty();
////                TxtEmailIdFlag = true;
////            }
////        }

////        $("#TxtPasswordValidate").empty();
////        if ($("#TxtPassword").val() == "") {
////            $("#TxtPasswordValidate").html("(*) Password Required..!!");
////            TxtPasswordFlag = false;
////        }
////        else {
////            if (!$("#TxtPassword").val().match($PasswordRegEx)) {
////                TxtPasswordFlag = false;
////                $("#TxtPasswordValidate").html('-- Invalid Password..!!<br/><ul style="padding:20px;"><li> Minimum 8 Maximum 12 Character Required.</li><li> Atleast One Uppercase Required.</li><li> Atleast One Lowercase Required.</li><li> Atleast One Numeric Required.</li><li> NO SPECIAL CHARACTERS ALLOWED.</li></ul>');
////            }
////            else {
////                $("#TxtPasswordValidate").empty();
////                TxtPasswordFlag = true;
////            }
////        }

////        if (TxtFNameFlag == true && TxtLNameFlag == true && TxtEmailIdFlag == true && TxtContactNoFlag == true && TxtPasswordFlag == true) {
            
////            fg();
////            //SignUp();
////        }
////        else {
////            alert("Invalid Inputs..!!")
////        }
////    });

////});
//////function fg() {
//////    var c = $("#TxtFName").val();
//////    alert(c);

//////}



////function fg()
////{
    
   
////    $.ajax
////    ({
////        datatype: "json",
////        type: "POST",
////        url: "/Home/CreateNewAccount",
////       /* data:{ 'json': JSON.stringify(json) },*/
////        data: '{Id:"0",FirstName:"' + $("#TxtFName").val().trim() + '",LastName:"' + $("#TxtLName").val().trim() + '",ContactNo:"' + $("#TxtContactNo").val().trim() + '",EmailId:"' + $("#TxtEmailId").val().trim() + '",Password:"' + $("#TxtPassword").val().trim() + '",Gender:"' + $("#DDL_Gender").val() + '"}',
////        contentType: "application/charset=UTF-8",
////        success: function (response)
////        {            
////            if (response.success = "success")
////            {
////                alert("data Inserted Successfully");
////                $("input").val("");
////                $("DDL_Gender").val("M");
////            }
////        },
////        error: function ()
////        {
////            alert("Unexpected error is occured sorry for incovinience..!!!")
////        }
////    });
////}



