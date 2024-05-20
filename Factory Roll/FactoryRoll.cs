using Prac4.Models_User;
using Prac4.Servicio;

namespace Prac4.Factory_Roll
{
    internal class FactoryRoll
    {
        public static IRoll GetRoll(UsuarioInformacion info)
        {
            string role;
            RegistroServicio servicio = new RegistroServicio();
            string password = info.password;

            if (password.Length > 0 && password[password.Length - 1] == '0')
            {
                role = "Cliente";
                RCliente cliente = new RCliente(servicio);
                 cliente.Roll(info, role);
            }
            if (password.Length > 0 && password[password.Length - 1] == '5')
            {
                role = "Proveedor";
                RProveedor proveedor = new RProveedor(servicio);
                proveedor.Roll(info, role);
            }
            if (password.Length > 0 && password[password.Length - 1] == '9')
            {
                role = "Empleado";
                REmpleadocs empleadocs = new REmpleadocs(servicio);
                empleadocs.Roll(info, role);
            }
            else
            {
                //info.role = "Ninguno";
                //RError error = null;
                //error.Roll(info);
            }
            return null;
        }
    }
}
