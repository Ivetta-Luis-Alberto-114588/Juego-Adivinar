using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adivinar
{
    public class Pregunta
    {
        public int IdPregunta { get; set; }
        public string PreguntaTexto { get; set; }
        public List<Respuesta> ListadoRespuestas { get; set; }

    }
}
