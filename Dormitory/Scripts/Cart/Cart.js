$(document).ready(
function () {
  $('#btnConfirm').on('click', function (e) {
    e.preventDefault();

    if ($('#tblViewCart tbody tr').length === 0) {
      alert('No dates in the cart to confirm the booking. Please add one.');
      return;
    }

    if (!$('form').valid()) return;


    if (!confirm("Do you really want to confirm?")) return;

    var data = {
      ContactName: $('#Name').val(),
      ContactEmail: $('#Email').val(),
      ContactNo: $('#ContactNo').val()
    }

    $.ajax({
      url: '/Cart/ConfirmCart',
      type: 'POST',
      data: data,
      success: function (result) {
        console.log(result);
        if (result.Success === true) {
          alert('Your booking has been confirmed.');
          window.location.href = "/Cart/BookingConfirmation?BookingId=" + result.BookingId;
        }
      }
    })
  });

  $('a[data-cartdetailid]').on('click', function () {
    var link = this;
    var cartDetailId = $(this).attr('data-cartdetailid');
    $(this).attr('disabled', 'disabled');
    $.get(
      '/Cart/RemoveCartDetail',
     'CartDetailID=' + cartDetailId,
      function (result) {
        console.log(result);
        $(link).removeAttr('disabled');
        if (result.Success) {
          $('tr[data-cartdetailid=' + cartDetailId + ']').remove();
        }
      },
      'json');
  }).attr('href', 'javascript:void(0);');
});


