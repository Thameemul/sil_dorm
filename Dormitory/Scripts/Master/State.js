function State(rootDir) {
  // Mode
  var screenMode = {
    isNew: false
  }
  var jsonState;
  var jsonCity;
  // Controls
  var controls = {
    new: $('#btnNew'),
    gridCountry: $('#list1'),
    gridState: $('#list2'),
    gridCity: $('#list3'),
    exit: $('#btnExit'),
    entry: {
      dialog: $('#Dialogvw'),
      message: $('#divMsg'),
      stateName: $('#txtState'),
      country: $('#ddlCountry'),
      form: $('#stateForm')
    }
  };

  // Methods
  var methods = {
    realoadGrid: function () {

      $.getJSON(rootDir + "Master/GetCountryList", null, function (data) {
        //jsonData = data;
        controls.gridCountry.jqGrid("clearGridData");

        $.each(data, function (i, item) {
          //alert(item.CountryId);
          controls.gridCountry.jqGrid("addRowData", i, item);
        });

        controls.gridCountry.trigger("reloadGrid");
      });

      $.getJSON(rootDir + "Master/GetStateList", null, function (data) {
        jsonState = data;
        //controls.gridState.jqGrid("clearGridData");

        //$.each(data, function (i, item) {
        //    controls.gridState.jqGrid("addRowData", i, item);
        //});

        //controls.gridState.trigger("reloadGrid");
      });

      $.getJSON(rootDir + "Master/GetCityList", null, function (data) {
        jsonCity = data;
        //controls.gridCity.jqGrid("clearGridData");

        //$.each(data, function (i, item) {
        //    controls.gridCity.jqGrid("addRowData", i, item);
        //});

        //controls.gridCity.trigger("reloadGrid");
      });
    },
    loadGrid: function (grid, jsonData, parentId, master) {
      //alert("test");
      grid.jqGrid("clearGridData");

      //loadGrid(controls.gridState, jsonState, countryId);grid, jsonData, parentId, master
      var data = jQuery.grep(jsonData, function (element, index) {
        if (master == "state")
          return (element.CountryId == parentId);
        else if (master == "city")
          return (element.StateId == parentId);
      });

      $.each(data, function (i, item) {
        grid.jqGrid("addRowData", i, item);
      });
    },
    editFormatter: function (cellvalue, options, rowObject) {
      //alert("test");
      var link = '<a href="#" id="Edit_' + rowObject.StateId + '_' + rowObject.CountryId + '" class="edit">' + "Edit" + '</a>';
      //var link = '<a href="/Appraisal/DepartmentMaster/?Id=' + rowObject.DepartmentId + '">' + "Open" + '</a>';
      console.log('Link::', link);
      return link;
    },
    stateNameFormatter: function (cellvalue, options, rowObject) {
      var link = '<span id="spanState_Desc_' + rowObject.StateId + '">' + rowObject.StateName + '</a>';
      console.log('Link::', link);
      return link;
    },
    isValid: function (mode, stateName, id) {
      $("#divMsg").html("").removeClass("foreColorRed");
      $("#divMsg").html("").addClass("foreColorGreen");
      if (mode == 'edit') {
        if (id == '') {
          $("#divMsg").html("Some problem in Edit").addClass("foreColorRed");
          return false;
        }
      }
      if (IsEmpty(stateName)) {
        $("#divMsg").html("Please enter the State Name").addClass("foreColorRed");
        return false;
      }
      if (mode == 'new') {
        if (methods.isExist(stateName)) {
          $("#divMsg").html("State Name already exists").addClass("foreColorRed");
          return false;
        }
      } else {
        if (methods.isExistById(stateName, id)) {
          $("#divMsg").html("State Name already exists").addClass("foreColorRed");
          return false;
        }
      }
      return true;
    },
    isExist: function (searchValue) {
      var resultElement = jQuery.grep(jsonData, function (element, index) {
        return (element.StateName == searchValue);
      });
      if (resultElement.length > 0)
        return true;

      return false;
    },
    isExistById: function (searchValue, id) {
      var resultElement = jQuery.grep(jsonData, function (element, index) {
        return (element.StateName == searchValue && element.StateId != id);
      });
      if (resultElement.length > 0)
        return true;

      return false;
    },
    clear: function (dialog) {
      $("#txtState").val("");
      $("#divMsg").html("");
      $('#ddlCountry').val();
      $("#ddlCountry").selectedIndex = 0;
      //$("#lblDialogID").text("");
      $(dialog).dialog('close');
    },
    save: function () {
      //toastr.error('Please fix the errors.', 'Error');
      var stateName = $("#txtState").val();
      var countryId = $('#ddlCountry').val();
      if (screenMode.isNew === true) {
        //alert('new');
        if (controls.entry.form.valid()) {
          alert('new1');

          $.ajax({
            type: "POST",
            url: rootDir + "Master/SaveState", //'@Url.Action("SaveRecord", "Master")',
            //url: '@Url.Action("SaveRecord", "Master")',controls.entry.form.serialize(), //
            //data: { "id": -1, "stateName": stateName, "countryId": countryId },
            data: controls.entry.form.serialize(),
            beforeSend: function () { },
            success: function (data) {
              if (data.success == true) {
                //$("#divMsg").html(data.message).addClass("foreColorGreen");
                toastr.info(data.message);
                setTimeout(function () {
                  reloadGrid();
                  return false;
                }, 70);
              } else {
                //alert(data.message);
                toastr.error(data.message);
              }
            }
          });
        }
      } else {

        var id = $("#StateId").val();

        if (controls.entry.form.valid()) {
          //alert('edit ' + rootDir);
          $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: rootDir + "Master/SaveState", //'@Url.Action("SaveRecord", "Master")',
            //data: { "id": id, "stateName": stateName, "countryId": countryId },
            data: controls.entry.form.serialize(),
            dataType: "json",
            beforeSend: function () { },

            success: function (data) {
              if (data.success == true) {
                //$("#divMsg").html(data.message).addClass("foreColorGreen");
                toastr.info(data.message);
                setTimeout(function () {
                  methods.realoadGrid();
                  //Window.history(-1);
                  return false;
                }, 70);
                //setTimeout(function () { window.location.replace("StateList"); }, 70);
              } else {
                toastr.error(data.message);
                //alert(data.message);
              }
            }
          });
        }
      }
    }
  }

  // UI
  $(".add").on("click", function () {
    screenMode.isNew = true;
    //alert(screenMode.isNew);
    //controls.entry.dialog.dialog("open");
    controls.entry.dialog.dialog({
      title: "New State",
      width: 500,
      buttons: {
        Save: function () {
          methods.save();
        },
        Close: function () {
          methods.clear(this);
        }
      },
      modal: true
    });
  });

  $(".edit").on("click", function () {
    screenMode.isNew = false;
    //alert("test");
    //$("#rwDialogID").show();
    var str = $(this).attr("id").split("_");
    id = str[1];
    var countryId = str[2];

    $("#txtState").val($("#spanState_Desc_" + id).text());
    $("#StateId").val(id);
    //var newId = $("#StateId").val();
    //alert('test ' + newId);
    $("#ddlCountry").val(countryId); //countryId$("#ddlProject").val($('option:selected', $(this)).text());
    //controls.entry.dialog.dialog("open");
    controls.entry.dialog.dialog({
      title: "Edit State",
      width: 500,
      buttons: {
        Save: function () {
          methods.save();
        },
        Close: function () {
          methods.clear(this);
        }
      },
      modal: true
    });
  });

  methods.realoadGrid();

  controls.gridCountry.jqGrid({
    datatype: "local",
    width: '100%',
    colNames: ['CountryId', 'Country Name', 'Edit'],
    colModel: [
        { name: 'CountryId', index: 'CountryId', hidden: true },
        { name: 'CountryName', index: 'CountryName', width: 150, align: "left" },
        { name: 'openEditor', index: 'openEditor', width: 50, formatter: methods.editFormatter, align: "center" }
    ],
    gridview: true,
    rownumbers: true,
    rowNum: 25,
    rowList: [10, 25, 50],
    pager: '#pager1',
    viewrecords: true,
    caption: '<span style="font-size:16px">Country List</span>',
    height: 'auto',
    onSelectRow: function (e) {
      //alert('Start0');
      var countryId = $(controls.gridCountry).jqGrid('getCell', e, 'CountryId');
      //alert('Start');
      methods.loadGrid(controls.gridState, jsonState, countryId, "state");//controls.gridState, jsonState, countryId, "state"
      //alert('End');
    }

  });


  controls.gridState.jqGrid({
    datatype: "local",
    width: '100%',
    colNames: ['StateId', 'State Name', 'Country Name', 'Edit', 'CountryId'],
    colModel: [
        { name: 'StateId', index: 'StateId', hidden: true },
        { name: 'StateName', index: 'StateName', width: 150, formatter: methods.stateNameFormatter, align: "left" },
        { name: 'CountryName', index: 'CountryName', width: 150, align: "left" },
        { name: 'openEditor', index: 'openEditor', width: 50, formatter: methods.editFormatter, align: "center" },
        { name: 'CountryId', index: 'CountryId', hidden: true }
    ],
    gridview: true,
    rownumbers: true,
    rowNum: 25,
    rowList: [10, 25, 50],
    pager: '#pager2',
    viewrecords: true,
    caption: '<span style="font-size:16px">State List</span>',
    height: 'auto',
    onSelectRow: function (e) {
      //alert('Start0');
      var stateId = $(controls.gridState).jqGrid('getCell', e, 'StateId');
      //alert('Start');
      methods.loadGrid(controls.gridCity, jsonCity, stateId, "city");//controls.gridState, jsonState, countryId, "state"
      //alert('End');
    },
    gridComplete: function () {
      //alert("e");
      var countryId = $(controls.gridState).jqGrid('getCell', 0, 'CountryId');
      //alert('Start');
      methods.loadGrid(controls.gridState, jsonState, countryId, "state");//controls.gridState, jsonState, countryId, "state"
      //alert('End');
    }

  });


  controls.gridState.closest("div.ui-jqgrid-view").children("div.ui-jqgrid-titlebar").css("text-align", "center").children("span.ui-jqgrid-title").css("float", "none");

  controls.gridCity.jqGrid({
    datatype: "local",
    width: '100%',
    colNames: ['CityId', 'City Name', 'State Name', 'Edit', 'StateId'],
    colModel: [
        { name: 'CityId', index: 'CityId', hidden: true },
        { name: 'CityName', index: 'CityName', width: 150, align: "left" },
        { name: 'StateName', index: 'StateName', width: 150, align: "left" },
        { name: 'openEditor', index: 'openEditor', width: 50, formatter: methods.editFormatter, align: "center" },
        { name: 'StateId', index: 'StateId', hidden: true }
    ],
    gridview: true,
    rownumbers: true,
    rowNum: 25,
    rowList: [10, 25, 50],
    pager: '#pager3',
    viewrecords: true,
    caption: '<span style="font-size:16px">City List</span>',
    height: 'auto',
  });

  alert("test");
  var countryId = $(controls.gridCountry).jqGrid('getCell', 0, 'CountryId');
  alert(countryId);
  methods.loadGrid(controls.gridState, jsonState, countryId, "state");//controls.gridState, jsonState, countryId, "state"
};
