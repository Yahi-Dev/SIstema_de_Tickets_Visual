using Prac4.Correo.Services;
//using Prac4.Correo.Services;
using Prac4.Correo.ModelsCorreo;

namespace Prac4.Correo
{
    public class MetodoGmail
    {
        private readonly IGmailService _mailService;

        public MetodoGmail(IGmailService mailService)
        {
            _mailService = mailService;
        }

        public void SendGmail(string para, string asunto, string contenido)
        {

            GemailDTO request = new GemailDTO
            {
                Para = para,
                Asunto = asunto,
                Contenido = contenido
            };

            _mailService.SendEmail(request);
        }
    }
}
