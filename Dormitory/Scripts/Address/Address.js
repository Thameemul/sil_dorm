$(document).ready(
function () {
 
    $('#State').attr('disabled', 'disabled');
    $('#CityId').attr('disabled', 'disabled'); 

  $('#Country').on('change', function () {
    var t = $(this).find('option:selected');
    $.ajax({
      url: 'GetStateByCountry',
      data: 'CountryId=' + t.attr('value'),
      type: 'GET',
      success: function (result) {
        var ddState = $('#State');
        var ddCity = $('#CityId');
        ddState.removeAttr('disabled');
        ddCity.attr('disabled', 'disabled');
        ddState.html('');
        ddState.append($("<option />").val("0").text('< Select >'));
        ddCity.html('');
        ddCity.append($("<option />").val("0").text('< Select >'));
        $.each(result, function () {
          ddState.append($("<option />").val(this.StateId).text(this.StateName));
        });
      }
    })
  });

  $('#State').on('change', function () {
    var t = $(this).find('option:selected');
    $.ajax({
      url: 'GetCityByState',
      data: 'StateId=' + t.attr('value'),
      type: 'GET',
      success: function (result) {
        var ddCity = $('#CityId');
        ddCity.removeAttr('disabled');
        ddCity.html('');
        ddCity.append($("<option />").val("0").text('< Select >'));
        $.each(result, function () {
          ddCity.append($("<option />").val(this.CityId).text(this.CityName));
        });
      }
    })
  });

});
