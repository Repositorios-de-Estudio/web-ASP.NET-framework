using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistroEmpleados.Models
{
    public class MailModel
    {
        public string Desde { get;set; }
        public string Hacia { get; set; }
        public string Asunto { get; set; }
        public string Cuerpo { get; set; }
    }
}