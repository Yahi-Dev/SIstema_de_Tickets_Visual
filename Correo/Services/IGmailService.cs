using Prac4.Correo.ModelsCorreo;

namespace Prac4.Correo.Services
{
    public interface IGmailService
    {
        void SendEmail(GemailDTO request);
    }
}
