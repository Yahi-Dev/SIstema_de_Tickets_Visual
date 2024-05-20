using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Prac4.Models_User
{
    public class UsuarioInformacion
    {
        public string name { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public string mailAddress { get; set; }
        public string password { get; set; }
        public string phoneNumber { get; set; }

        static string role { get; set; }
    }
}
