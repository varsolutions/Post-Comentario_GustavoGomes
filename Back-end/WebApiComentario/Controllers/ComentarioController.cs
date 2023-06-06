using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApiComentario.Application.Comentario;
using WebApiComentario.Repository;

namespace WebApiComentario.Controllers
{
    [ApiController]
    [Route("[controller]")]
     
    public class ComentarioController: ControllerBase
    {

            private readonly IPostService _postService;

            public ComentarioController(IPostService postService )
            {
                _postService = postService;
            }


        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult SalvarComentario([FromBody] postRequest request)
        {
            
            var comentario = _postService.SalvarComentario(request);
            if (comentario)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }

        }



        [HttpGet]
        [Route("postagens")]
        public List<postResponse> postagens()
        {
            var postagem = _postService.PegarPostagens();
            return postagem;
                
        }
    }
}


