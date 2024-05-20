using Prac4.Correo.ModelsCorreo;
using Prac4.Estrategy.Entidades;

namespace Prac4.Estrategy
{
    public interface IMensajeria
    {
        Task SendAll(CuerpoMensaje info);

        void SendEmail (GemailDTO email);
    }
}
