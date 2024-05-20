using Prac4.Logica;
using Prac4.Models_User;

namespace Prac4.Servicio
{
    public class RegistroServicio
    {
        public string RegistrarUsuario(UsuarioInformacion info, string roll)
        {
            if (info == null)
            {
                return "false";
            }

            Resolucion resolver = new Resolucion();
            resolver.registro(info, roll);

            return "true";
        }
    }
}
