
window.onload = function () {
    var cb = document.getElementById("isSpecCb")
    var specInput = document.getElementById("specInput")
    var usualInput = document.getElementById("usualInput")

    specInput.style.display = "none"

    var state = false

    cb.oninput = function (e) {

        state = !state

        if (state) {
            specInput.style.display = "inherit"
            usualInput.style.display = "none"
        }
        else {
            specInput.style.display = "none"
            usualInput.style.display = "inherit"
        }
    }
}