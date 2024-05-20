using Prac4.Correo;
using Prac4.Correo.ModelsCorreo;
using Prac4.Correo.Services;
using Prac4.Telegram;
using Prac4.WhatsApp;

namespace Prac4.Estrategy
{
    public class FactoryMensajeria
    {
        private readonly IConfiguration _configuration;
        private readonly IGmailService _mailService;

        public FactoryMensajeria(IConfiguration configuration, IGmailService gmailService)
        {
            _configuration = configuration;
            _mailService = gmailService;
        }

        public IMensajeria GetMensajeria(string name, IConfiguration configuration1,IGmailService gmailService) 
        {
            switch(name)
            {
                case "1":
                    return new WhatsAppEnvio();
                case "2":
                    return new TelegramEnvio();
                default:
                    throw new InvalidOperationException("OPCION NO VALIDA");
            }
        }
    }
}
