$(document).ready(function () {
  $("#loginInicio").click(function (event) {
    event.preventDefault();

    var userName_usuario = $("#usernameInicio").val();
    var password_usuario = $("#passwordinicio").val();

    var info = {
      username: userName_usuario,
      password: password_usuario,
    };
    fetch("https://localhost:7065/Prac4JuanR054r10/1niCI053510n", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(info),
    })
    .then(function(response){
      if(response.ok)
      {
        return response.text();
      }
      else{
        throw new Error("Datos no existentes, favor registrarse");
      }
    })
    .then(function(data){
        if (data !== "INICIO DE SESION FALLIDO") {
          localStorage.setItem("username", userName_usuario);
         
          var ultimoDigito = password_usuario.slice(-1);

          switch (ultimoDigito) {
            case "0":
              window.location = "../HTML/Acesso.html";
            break;

            case "5":
              window.location = "../HTML/AcessoProveedor.html";
            break;
            
            case "9":
              window.location = "../HTML/AcessoEmpleado.html";
            break;

            default:
              window.location = "../HTML/Login.html";
            break;
          }
        }
        if (data === "INICIO DE SESION FALLIDO") {
          throw new Error("Usuario no encontrado :(");
        }
      })
      .catch(function(error){
        $("#resultado").text(error.message);
      })
  });
});
