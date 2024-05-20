using Prac4.Models_User;
using Prac4.Servicio;

namespace Prac4.Factory_Roll
{
    public class RCliente : IRoll
    {
        private readonly RegistroServicio Service;

        public RCliente(RegistroServicio service)
        {
            this.Service = service;
        }
        public void Roll(UsuarioInformacion info, string roll)
        {
            string password = info.password;
            
                roll = "Cliente";
                info.password = password;
                Service.RegistrarUsuario(info, roll);
            
        }
    }
}
