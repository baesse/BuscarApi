using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuscarApi.Models.Poco
{
    public class Usuario
    {
        public String _nome { get; set; }
        public String _email { get; set; }
        public String _senha { get; set; }
        public int _id { get; set;}
        public int _idperfil { get; set; }

    }
}