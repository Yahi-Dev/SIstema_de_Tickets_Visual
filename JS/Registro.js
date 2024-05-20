const nombre = document.getElementById("nombreRegistro");
const apellido = document.getElementById("apellidoRegistro");
const usuarioname = document.getElementById("usernameRegistro");
const email = document.getElementById("email");
const password = document.getElementById("passwordRegistro");
const number = document.getElementById("PhoneNumber");
const enviar = document.getElementById("submitRegistro");

enviar.addEventListener("click", enviarData);

function enviarData(e) {
  if (
    nombre.value &&
    apellido.value &&
    usuarioname.value &&
    email.value &&
    password.value &&
    number.value
  ) {
    e.preventDefault();
    const info = {
      name: nombre.value,
      lastName: apellido.value,
      userName: usuarioname.value,
      mailAddress: email.value,
      password: password.value,
      phoneNumber: number.value,
    };
    fetch("https://localhost:7065/R3g15t7ro", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(info),
    })
      .then((response) => response.json())
      .then((data) => {
        console.log(data);
      })
      .catch((error) => console.error("Error: ", error));
  } else{
    e.preventDefault();
    alert("XXX Por favor, llene todos los registros XXX");
  }
}
