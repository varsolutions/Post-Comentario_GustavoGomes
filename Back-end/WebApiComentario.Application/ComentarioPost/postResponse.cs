using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebApiComentario.Application.Comentario
{
    public class postResponse
    {
        public string Usuario { get; set; }

        public string Comentario { get; set; }

        public string Data { get; set; }

        public int id{ get; set; }
    }
}