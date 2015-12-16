$(document).ready(
function () {
  var t = $('[name=FromDate]');
  t.val(t.attr('data-value'));

  t = $('[name=ToDate]');
  t.val(t.attr('data-value'));

  $('#RoomType').on('change', function () {
    var t = $(this).find('option:selected');
    $.ajax({
      url: 'GetRoomsByType',
      data: 'RoomType=' + t.attr('value'),
      type: 'GET',
      success: function (result) {
        var dropdown = $('#RoomId');
        dropdown.html('');
        $.each(result, function () {
          dropdown.append($("<option />").val(this.RoomId).text(this.RoomNo));
        });
      }
    })
  });

  $('#SelectAll').on('click', function () {
    if ($(this).is(':checked')) {
      $('#tblAvailableDates :checkbox:not([disabled])').prop('checked', true);
    } else {
      $('#tblAvailableDates :checkbox:not([disabled])').prop('checked', false);
    }
  });

  $('#btnAddCart').on('click', function () {

    var dates = $('#tblAvailableDates input[name=chkDate]:checked');
    if (dates.length == 0) {
      alert('No date is selected.');
      return;
    }
    var that = this;
    var data = {
      CartId: $(this).attr('data-cartid'),
      RoomId: $('#RoomId :selected').attr('value'),
      Dates: {}
    };

    $.each(dates, function () {
      var date = $(this).attr('data-date');
      //var o = {};
      data.Dates[date] = $('select[data-date=\'' + date + '\'] option:selected').text();
      //data.Dates.push(o);
    });

    if (data.Dates.length == 0) return;

    data.Dates = JSON.stringify(data.Dates);

    $(that).button('Adding...').append('<i class="fa fa-refresh fa-spin fa-fw"></i>').attr('disabled', 'disabled');

    $.ajax({
      url: '/Cart/AddItems',
      data: data,
      type: 'POST',
      success: function (result) {
        console.log(result);
        if (result.Success === true) {
          $(that).attr('data-cartid', result.ReturnValue.CartId).removeAttr('disabled').button('reset').find('li').remove();
          $('#btnViewCart [class=badge]').text(result.ReturnValue.TotalDates);
        }
      }
    })
  });

  $('#btnViewCart').on('click', function () {
    var cartid = $('#btnAddCart').attr('data-cartid');
    var totalDates = parseInt($('#btnViewCart span').text())
    cartid = typeof cartid === 'undefined' ? 0 : parseInt(cartid);
    if (cartid === 0 || totalDates === 0) {
      alert('No dates are added to the cart yet.');
      return;
    }
    window.location.href = "/Cart/ViewCart";
  });

  $('#btnSubmit').on('click', function (e) {
    if ($('#RoomId :selected').length === 0) {
      alert('Please select a room.');
      e.preventDefault();
      return;
    }

    $('form').attr('action', '/Booking/GetBooking');
  });

});
