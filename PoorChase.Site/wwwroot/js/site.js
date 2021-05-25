onload = () => {
    //Get inputs of login partail & add event listeners
    let inputs = [];
    inputs.push(document.getElementById("login_username"));
    inputs.push(document.getElementById("login_password"));
    for (let i = 0; i < inputs.length; i++) {
        if (inputs[i] != null) {
            inputs[i].addEventListener("change", clearErrorMessage);
        }
    }

    //Get select control from home page & add event listeners
    let sortSelect = document.getElementById("select-order");
    if (sortSelect) {
        sortSelect.value = getCookie("SortBy");
        sortSelect.addEventListener("change", setSortBy);
    }

    //Pop up a confirmation modal
    let modal = $('#pop-up-modal');
    if (modal) {
        modal.modal('show');
    }
}

//Clear the error message on login partial
const clearErrorMessage = () => {
    let errorMessage = document.getElementById("error_message");
    if (errorMessage.innerText) {
        errorMessage.innerText = null;
    }
}

//Set the sorting method by SortBy cookie
const setSortBy = () => {
    let sortSelect = document.querySelector("#select-order");
    document.cookie = `SortBy=${sortSelect.value}`;
    window.location.replace(window.location.href);
}

//Get cookie value by cookie key
function getCookie(cname) {
    let name = cname + "=";
    let decodedCookie = decodeURIComponent(document.cookie);
    let ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}
