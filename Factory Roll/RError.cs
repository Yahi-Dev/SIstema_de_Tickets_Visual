using Prac4.Models_User;
using Prac4.Servicio;

namespace Prac4.Factory_Roll
{
    public class RError : IRoll
    {
        private readonly RegistroServicio Service;

        public RError(RegistroServicio service)
        {
            Service = service;
        }
        public void Roll(UsuarioInformacion info, string roll)
        {
             roll = "Ninguno";
            Service.RegistrarUsuario(info, roll);
        }

    }
}
