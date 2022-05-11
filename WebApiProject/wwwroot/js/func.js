

var count = 0;

function LogIn() {
    fetch('../api/User/' + document.getElementById("email").value + '/' + document.getElementById("password").value)
        .then(response => {
            if (response.status == 204) {
                alert("שם משתמש או סיסמא אינם תקינים")
            }
            if (response.ok) {
                return response.json();
            }
            else {
                throw new Error("status Code is:" + response.status);
            }
        })
        .then(data => {
            sessionStorage.setItem('currentUser', JSON.stringify(data))
            window.location.href = "../html/HomePage.html?user=" + JSON.stringify(data);
        })
       
}

function user() {
    var c = JSON.parse(sessionStorage.getItem("currentUser"));
    document.getElementById("HomePage").textContent = c.firstName + " " + c.lastName;
}

function NewUser() {
    document.getElementById("a").style.display = "block";
};

function saveUser() {
    let user = {
        Email: document.getElementById("Nmail").value,
        Password: document.getElementById("Npassword").value,
        FirstName: document.getElementById("Nf_name").value,
        LastName: document.getElementById("Nl_name").value
    }

    fetch("../api/User", {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(user)
    }).then(res => {
        if (res.ok)
            alert("????????? ok");
        else
            res.json().then(error => { alert(JSON.stringify(error.errors)); });
    })

}


let c_user = JSON.parse(sessionStorage.getItem('currentUser'));


function edit() {
    document.getElementById("div_change_details").style.display = "block";
    document.getElementById("change_user_name").value = c_user.email;
    document.getElementById("change_user_password").value = c_user.password;
    document.getElementById("change_first_name").value = c_user.firstName;
    document.getElementById("change_last_name").value = c_user.lastName;
}

function update() {
    let changedUser = {
        userId: JSON.parse(sessionStorage.getItem('currentUser')).userId,
        email: document.getElementById("change_user_name").value,
        password: document.getElementById("change_user_password").value,
        firstName: document.getElementById("change_first_name").value,
        lastName: document.getElementById("change_last_name").value,
    }

    fetch("../api/User/" + changedUser.userId, {
           method: "PUT",
           headers: {
           'Content-Type': 'application / json'
       },
         body: JSON.stringify(changedUser)
    }).then((response) => {
           if (response.ok) {
                sessionStorage.setItem('currentUser', JSON.stringify(changedUser))
                alert("your new details is:" + JSON.stringify(changedUser))
            }
           else { throw new Error("your details isn't update") }
        })
}