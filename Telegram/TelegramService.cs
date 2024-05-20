using Prac4.Estrategy;
using Prac4.Estrategy.Entidades;

namespace Prac4.Telegram
{
    public class TelegramService
    {
        private readonly IMensajeria _telegramService;

        public TelegramService(IMensajeria telegramService)
        {
            _telegramService = telegramService;
        }

        public void EnviarMensaje(CuerpoMensaje cuerpo)
        {
            _telegramService.SendAll(cuerpo);
        }
    }
}
