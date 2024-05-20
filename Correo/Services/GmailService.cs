using Prac4.Correo.ModelsCorreo;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using Prac4.Estrategy.Entidades;

namespace Prac4.Correo.Services
{
    public class GmailService : IGmailService
    {
        private readonly IConfiguration _confi;

        public GmailService(IConfiguration confi)
        {
            _confi = confi;
        }

        public void SendEmail(GemailDTO request)
        {
            var Gmail = new MimeMessage();
            Gmail.From.Add(MailboxAddress.Parse(_confi.GetSection("Email:UserName").Value));
            Gmail.To.Add(MailboxAddress.Parse(request.Para));
            Gmail.Subject = request.Asunto;
            Gmail.Body = new TextPart(TextFormat.Html)
            {
                Text = request.Contenido
            };

            using var smtp = new SmtpClient();
            smtp.Connect(
                _confi.GetSection("Email:Host").Value,
                Convert.ToInt32(_confi.GetSection("Email:Port").Value),
                SecureSocketOptions.StartTls
                );

            smtp.Authenticate(_confi.GetSection("Email:UserName").Value, _confi.GetSection("Email:PassWord").Value);

            smtp.Send(Gmail);
            smtp.Disconnect(true);
        }

        public Task SendAll(CuerpoMensaje dato)
        {
            throw new NotImplementedException();
        }
    }
}







