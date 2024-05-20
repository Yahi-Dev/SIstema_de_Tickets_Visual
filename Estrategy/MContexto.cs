using Prac4.Correo.ModelsCorreo;
using Prac4.Estrategy.Entidades;

namespace Prac4.Estrategy
{
    public class MContexto
    {
        private IMensajeria _objeto;

        public MContexto (IMensajeria objeto)
        {
                _objeto = objeto;
        }

        public void Ejecutar(CuerpoMensaje cuerpo)
        {
            _objeto.SendAll(cuerpo);
        }

        public void EjecutarEmail(GemailDTO email)
        {
            _objeto.SendEmail(email);
        }
    }
}
