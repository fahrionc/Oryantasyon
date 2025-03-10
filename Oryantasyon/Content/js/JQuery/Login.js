function Register() {
    var formData = $("#signup-form").serialize();

    $.ajax({
        type: "POST",
        url: "/Login/Register",
        data: formData,
        success: function (response) {
            alert("Kayıt başarılı!");
        },
        error: function (xhr, status, error) {
            alert("Hata oluştu: " + xhr.responseText);
        }
    });
}
function Login() {
    var formData = $("#signin-form").serialize();

    $.ajax({
        type: "POST",
        url: "/Login/SingIn",
        data: formData,
        success: function (response) {
            if (response.success==true) {
                window.location.href = "Car/Index";
            } else {
                console.log("Geçersiz giriş denemesi.");
            }
        },
        error: function (xhr, status, error) {
            console.log("Hata oluştu: " + xhr.responseText);
        }
    });
}
