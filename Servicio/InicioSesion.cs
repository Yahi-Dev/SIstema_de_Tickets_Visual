using Prac4.Logica;
using Prac4.Models_User;

namespace Prac4.Servicio
{
    public class InicioSesion
    {
        public string IniciarSesion(InicioUsuario usuario)
        {
            if (usuario == null)
            {
                return "Datos Incorrectos";
            }

            Resolucion resolver = new Resolucion();
            return resolver.InicioDeSesion(usuario);

            
        }
    }
}
