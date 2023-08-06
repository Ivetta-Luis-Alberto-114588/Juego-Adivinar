using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adivinar
{
    public class Respuesta
    {
        public int IdRespuesta { get; set; }
        public string RespuestaTexto { get; set; }
        public bool EsValida { get; set; } = false;
    }
}
