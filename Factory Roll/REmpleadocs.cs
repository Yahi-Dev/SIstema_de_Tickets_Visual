using Prac4.Models_User;
using Prac4.Servicio;

namespace Prac4.Factory_Roll
{
    public class REmpleadocs : IRoll
    {
        private readonly RegistroServicio Service;

        public REmpleadocs (RegistroServicio Service)
        {
            this.Service = Service;
        }
        public void Roll(UsuarioInformacion info, string roll)
        {
            string password = info.password;
            
                roll = "Empleado";
                info.password = password;
              Service.RegistrarUsuario(info, roll);
            

        }
    }
}
