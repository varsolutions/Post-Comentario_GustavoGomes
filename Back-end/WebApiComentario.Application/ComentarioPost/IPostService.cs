using System;
using System.Collections.Generic;
using System.Text;
using WebApiComentario.Repository;

namespace WebApiComentario.Application.Comentario
{
    public interface IPostService
    {
        List<postResponse> PegarPostagens();

        bool SalvarComentario(postRequest request);

    }
}
