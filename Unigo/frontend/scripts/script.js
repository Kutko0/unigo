$('#myList a').on('click', function (e) {
  e.preventDefault()
  $(this).tab('show')
})

var stopPoints = 0;
var limit = 3;

var stopPointInput1 = '<div id="stopPoint'
var stopPointInput2 = ' class="d-inline-flex align-items-center mt-1 w-100"><input type="text" class="form-control" placeholder="Enter stop point"><a class="btn btn-primary text-white" role="button" id="addStopPoint" onclick="removeStopPoint('
var stopPointInput3 = ')"><i class="fas fa-trash"></i></a></div>';

function addStopPoint () {
  if (stopPoints < limit) {
    stopPoints++;
    $('#location').append(stopPointInput1 + stopPoints + '"' + stopPointInput2 + stopPoints + stopPointInput3);
  }
}

function removeStopPoint (stopPointNumber) {
  $('#stopPoint' + stopPointNumber).remove();
  if (stopPointNumber == 1) {
    $('#stopPoint2 a' ).attr('onclick', 'removeStopPoint(1)')
    $('#stopPoint2').attr('id', 'stopPoint1');
    $('#stopPoint3').attr('id', 'stopPoint2');
  } else if (stopPointNumber == 2) {
    $('#stopPoint3 a').attr('onclick', 'removeStopPoint(2)')
    $('#stopPoint3').attr('id', 'stopPoint2');
  }

  if (stopPoints != 0) {
    stopPoints--;
  }
}