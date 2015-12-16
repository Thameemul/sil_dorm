


function CheckLengthValue(value, msg) {
    if ($.trim(value).length == 0) {
        alert(msg);
        return false;
    }
}

function CheckMinValue(object, minLength, msg) {
    if ($.trim(object.val()).length < minLength) {
        alert(msg);
        object.focus();
        return false;
    }
}

function CheckLengthDdl(object, msg) {
    //alert('yes');
    if ($.trim(object.val()) == 0) {
        alert("Please select the " + msg);
        object.focus();
        return false;
    }
}

function CheckLength(object, msg) {
    //alert('yes');
    if ($.trim(object.val()).length == 0) {
        alert("Please enter the " + msg);
        object.focus();
        return false;
    }
}

function DateDiff(myDate, msg) {
    var currentDate = new Date();
    currentDate = currentDate.getFullYear().toString() + (('0' + (currentDate.getMonth() + 1)).substr(-2, 2).toString()) + currentDate.getDate().toString();

    var dt = $.trim(myDate.val()).split('/');
    var inputDate = dt[2] + dt[1] + dt[0];

    if (eval(inputDate) <= eval(currentDate)) {
        alert(msg);
        myDate.focus();
        return false;
    }
    return true;
}

function DateDiff(firstDate, secondDate, msg) {
    //alert("yes");
    var dt = $.trim(firstDate.val()).split('/');
    var firstDate1 = dt[2] + dt[1] + dt[0];

    dt = $.trim(secondDate.val()).split('/');
    var secondDate1 = dt[2] + dt[1] + dt[0];

    //alert(firstDate + "\n" + secondDate);

    if (eval(secondDate1) < eval(firstDate1)) {
        alert(msg);
        secondDate.focus();
        return false;
    }
    return true;
}

function validateEmailId(emailId) {
    alert(emailId);
//    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
//    if (!emailReg.test($emailId))
//        return false;

    return true;
}

//End JQuery

function MouseOver(myObj, className) {
    myObj.className = className;
}

function MouseOut(myObj, className) {
    myObj.className = className;
}

// Trim function in javascript 
function Trim(str) {
    while (str.substring(0, 1) == ' ') // check for white spaces from beginning
    {
        str = str.substring(1, str.length);
    }
    while (str.substring(str.length - 1, str.length) == ' ') // check white space from end
    {
        str = str.substring(0, str.length - 1);
    }
    return str;
}


            function open() {
                alert("yes1");
                //window.open("/Accounts/ProjectEntry.aspx?Master=Project Entry");
            }


function IsEmpty(str) {
    if (Trim(str).length == 0) return true;
}

function UpperCase(event) {
    //alert(event.keyCode);

    if (navigator.appName == "Microsoft Internet Explorer") // IE
    {
        key = event.keyCode;
    }
    else// if (e.which) // Netscape/Firefox/Opera
    {
        key = event.which;
    }
    
    //key = window.event.keyCode;
    if (key >= 97 && key < 123) {

        if (navigator.appName == "Microsoft Internet Explorer") // IE
        {
            event.keyCode = key - 32;

        }
        else {

            control.value = key - 32;

        }
    }
    /*if ((key > 0x60) && (key < 0x7B))
    window.event.keyCode = key - 0x20;*/
}

function onlyNumbers(evt) {
    var e = event || evt; // for trans-browser compatibility
    var charCode = e.which || e.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;

}

function PositiveNumber(objName,event) {
    var control = document.getElementById(objName);
    
    if (navigator.appName == "Microsoft Internet Explorer") // IE
    {
        key = event.keyCode;
    }
    else// if (e.which) // Netscape/Firefox/Opera
    {
        key = event.which;
    }
    //key 8 (Backspace) and 0 (arrows,delete...) These for Other than IE
    if ((key >= 48 && key <= 57) || (key == 46 && control.value.indexOf(".") == -1) || (key == 8 || key ==0)) {
    }
    else {
        if (navigator.appName == "Microsoft Internet Explorer") // IE
            window.event.keyCode = null;
        else
            event.preventDefault(); 
    }
}

function PositiveNumberNoDots(objName, event) {
    var control = document.getElementById(objName);
    
    if (navigator.appName == "Microsoft Internet Explorer") // IE
    {
        key = event.keyCode;
    }
    else// if (e.which) // Netscape/Firefox/Opera
    {
        key = event.which;
    }
    //key 8 (Backspace) and 0 (arrows,delete...) These for Other than IE
    if ((key >= 48 && key <= 57) || (key == 8 || key == 0)) {
    }
    else {
        if (navigator.appName == "Microsoft Internet Explorer") // IE
            window.event.keyCode = null;
        else
            event.preventDefault(); 
    }
}

function SetBackColor(controlName) {
    var control = document.getElementById(controlName);
    control.className = 'currentControlBackColor';
//    var errorText = document.getElementById('errText');
//    errorText.innerHTML = control.title;
}
function RemoveBackColor(controlName) {
    var control = document.getElementById(controlName);
    control.className = '';
    var errorText = document.getElementById('errText');
    errorText.innerHTML = "&nbsp;";
}

function IsTextEmpty(control, errorText, errMessage) {
    if (IsEmpty(control.value)) return ErrorSetFocus(control, errorText, errMessage)
}

function IsNumberEmpty(control, errorText, errMessage) {
    if (Trim(control.value).length == 0 || isNaN(control.value) || parseInt(control.value) == 0) return ErrorSetFocus(control, errorText, errMessage)
}

function IsDropDownListEmpty(control, errorText, errMessage) {
    if (control.selectedIndex == 0) return ErrorSetFocus(control, errorText, errMessage)
}

function IsGreaterControl(minControl, maxControl, errorText, errMessage) {
    if (eval(minControl.value) > eval(maxControl.value)) return ErrorSetFocus(maxControl, errorText, errMessage)
}

function IsGreaterValue(control, range, errorText, errMessage) {
    if (eval(control.value) > range) return ErrorSetFocus(control, errorText, errMessage)
}

function ErrorSetFocus(control, errorText, errMessage) {
    //control.className = 'errorBorder';
    errorText.className = 'ErrorCaption';
    errorText.innerHTML = errMessage;
    control.focus();
    return true;
}  

    function OnFocus(myControl,DropDown) {
        var lblError = document.getElementById('ctl00_head_lblError');
        var ControlType = 'Enter';
        if (DropDown == 'D')
            ControlType = "Select";

        lblError.innerText = "Please " + ControlType + " the " + myControl;

    }

    function SetMaxLength(textBox, e, length) {

        var mLen = textBox["MaxLength"];
        if (null == mLen)
            mLen = length;

        var maxLength = parseInt(mLen);
        if (!checkSpecialKeys(e)) {
            if (textBox.value.length > maxLength - 1) {
                if (window.event)//IE
                    e.returnValue = false;
                else//Firefox
                    e.preventDefault();
            }
        }
    }
    function checkSpecialKeys(e) {
        if (e.keyCode != 8 && e.keyCode != 46 && e.keyCode != 37 && e.keyCode != 38 && e.keyCode != 39 && e.keyCode != 40)
            return false;
        else
            return true;
    } 
        
//        function IsValidatorVisibled() {
//            var controls = document.getElementsByTagName('span');
//            for (i = 0; i < controls.length; i++) {
//                //alert(controls[i].id + " = " + controls[i].style.visibility);
//                if (controls[i].style.visibility == "visible") {
//                    return true;
//                }
//            }
//        }

//            if (IsValidatorVisibled()) {
//                errorText.innerHTML = "* Required field cannot be left blank " + "<br>";
//                //return false;
    //            }

    