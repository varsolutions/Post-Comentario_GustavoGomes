using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using WebApiComentario.Repository;
using WebApiComentario.Repository.model;

namespace WebApiComentario.Application.Comentario
{
    public class postService : IPostService
    {
        private readonly ComentarioContext _context;

        public postService(ComentarioContext context)
        {
            _context = context;
        }

        public List<postResponse> PegarPostagens()
        {
            var PegarDb = _context.Posts.ToList();
            var ordemDecresnte = PegarDb.OrderByDescending(e => e.ID).ToList();
            var MostarLista = new List<postResponse>();
            foreach (var post in ordemDecresnte)
            {
                MostarLista.Add(new postResponse()
                {
                    
                    Comentario = post.Comentario,
                    Data = String.Format("{0:dd/MM/yyyy}",post.Hora),
                    Usuario = post.Usuario,
                    id = post.ID

                });

            }
            return MostarLista;
        }

        public bool SalvarComentario(postRequest request)
        {
            try
            {
                var nome = Nome(request);

                var Database = new tabComentarioPost()
                {
                    Comentario = request.Comentario,
                    Usuario = nome,
                    Hora = DateTime.Now
                };

                _context.Posts.Add(Database);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private string Nome(postRequest request)
        {
            if (request.Usuario == "")
            {
                return "an�nimo";
            }
            else
            {
                return request.Usuario;
            }
        }
    }
}
