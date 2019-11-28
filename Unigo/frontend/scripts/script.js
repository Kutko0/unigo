$('#myList a').on('click', function (e) {
  e.preventDefault()
  $(this).tab('show')
})

var stopPoints = 0;
function displayStopPoints () {
  stopPoints++;
  switch (stopPoints) {
    case 1:
      $("#stopPoint1").removeClass("d-none");
      break;
    case 2:
      $("#stopPoint2").removeClass("d-none");
      break;
    case 3:
      $("#stopPoint3").removeClass("d-none");
      break;
    default:
      console.log("Error while displaying elements")
      break;
  }
}