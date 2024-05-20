using Prac4.Correo.ModelsCorreo;
using Prac4.Estrategy;
using Prac4.Estrategy.Entidades;
using Telegram.Bot;

namespace Prac4.Telegram
{
    public class TelegramEnvio : IMensajeria
    {
        public async Task SendAll(CuerpoMensaje cuerpo)
        {
            var botClient = new TelegramBotClient("6402675291:AAHvaewh_JcZk96NLQpwnR4q7d2Sya2QIc0");

            try
            {
                await botClient.SendTextMessageAsync(cuerpo.Numero, cuerpo.Mensaje);
                Console.WriteLine("Mensaje enviado");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar mensaje: {ex.Message}");
            }
        }
        public void SendEmail(GemailDTO request)
        {
            throw new NotImplementedException();

        }
    }
}
