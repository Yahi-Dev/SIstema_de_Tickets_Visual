using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Asn1.Crmf;
using Prac4.Correo.ModelsCorreo;
using Prac4.Estrategy;
using Prac4.Estrategy.Entidades;
using RestSharp;
using static System.Net.WebRequestMethods;

namespace Prac4.WhatsApp
{
    public class WhatsAppEnvio : IMensajeria
    {
        public async Task SendAll(CuerpoMensaje cuerpo)
        {
            var url = "https://api.ultramsg.com/instance67312/messages/chat";
            var client = new RestClient(url);

            var request = new RestRequest(url, Method.Post);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("token", "x4pkbt6jmskvm7iv");
            request.AddParameter("to", cuerpo.Numero);
            request.AddParameter("body", "Se ha generado un reporte a las " + DateTime.Now + " " + cuerpo.Mensaje);

            RestResponse response = await client.ExecuteAsync(request);
            var output = response.Content;
            Console.WriteLine(output);
        }

        public void SendEmail(GemailDTO request)
        {
            throw new NotImplementedException();

        }
    }
}
