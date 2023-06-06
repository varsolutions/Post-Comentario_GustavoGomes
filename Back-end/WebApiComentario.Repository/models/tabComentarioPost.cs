using System;
using System.Buffers;
using System.ComponentModel.DataAnnotations;

namespace WebApiComentario.Repository.model
{
 
    public class tabComentarioPost
    {
        
        public string Usuario { get; set; }

        public string Comentario { get; set; }

        public DateTime Hora { get; set; }

        public int ID { get; set; }


    }
}
