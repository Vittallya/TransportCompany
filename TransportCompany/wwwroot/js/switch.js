

var p = document.getElementById("p")
var sp = document.getElementById("sp")

window.onload = function () {



    var cb = document.getElementById("cb")
    CbChanged(cb)

    //var specInput = document.getElementById("specInput")
    //var usualInput = document.getElementById("usualInput")

    //specInput.style.display = "none"

    //var state = false

    //cb.oninput = function (e) {

    //    state = !state

    //    if (state) {
    //        specInput.style.display = "inherit"
    //        usualInput.style.display = "none"
    //    }
    //    else {
    //        specInput.style.display = "none"
    //        usualInput.style.display = "inherit"
    //    }
    //}
}



function CbChanged(elem) {

    var display = "inherit";
    var none = "none"

    if (elem.checked) {
        p.style.display = none;
        sp.style.display = display;
    }
    else {

        sp.style.display = none;
        p.style.display = display;
    }
}

