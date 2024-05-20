using Org.BouncyCastle.Asn1.Mozilla;
using Prac4.Archivo_Json;
using Prac4.Archivo_Txt_Historial_Registro;
using Prac4.Correo;
using Prac4.Correo.Services;
using Prac4.Models_User;

namespace Prac4.Logica
{
    public class Resolucion
    {
        private static List<UsuarioInformacion> usuarios = new List<UsuarioInformacion>();
        //  private readonly IGmailService service;
        //private readonly IConfiguration _configuration;
        public void registro(UsuarioInformacion info, string roll)
        {
            string formattedNumber;

            string nombre = info.name;
            string apellido = info.lastName;
            string usuarionombre = info.userName;
            string email = info.mailAddress;
            string contraseña = info.password;
            string NumberPhone = info.phoneNumber;
            string Role = roll;

            NumberPhone = NumberPhone.Replace("-", "").Replace(" ", "");

            if (NumberPhone.Length == 10)
            {
                formattedNumber = $"{NumberPhone.Substring(0, 3)}-{NumberPhone.Substring(3, 3)}-{NumberPhone.Substring(6, 4)}";
            }
            else
            {
                formattedNumber = NumberPhone;
            }

            info.phoneNumber = formattedNumber;

            Logger.Instance.Log(nombre, Role, apellido, usuarionombre, email, contraseña, formattedNumber);
            usuarios.Add(info);
            saveJasonData.SerializeJsonFile(usuarios);

            //IGmailService gmailService = new GmailService(_configuration);
            //MetodoGmail metodoGmail = new MetodoGmail(gmailService);

            //metodoGmail.SendGmail(email);

        }

        public string InicioDeSesion(InicioUsuario usuario)
        {
            usuarios = saveJasonData.DeserializeJsonFile();

            var usuarioEncontrado = usuarios.Find(u => u.userName == usuario.username);

            if (usuarioEncontrado != null && usuarioEncontrado.password == usuario.password)
            {
                string UserInfoVALUE = $"{usuarioEncontrado.mailAddress} {usuarioEncontrado.phoneNumber}";
                return UserInfoVALUE;
            }
            else
            {
                return "INICIO DE SESION FALLIDO";
            }

        }
    }
}
