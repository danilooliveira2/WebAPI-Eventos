using Microsoft.AspNetCore.Mvc;
using WebAPI_Aprendizado.Models;

namespace WebAPI_Aprendizado.Controllers
{
    //Criar um novo Controlador e definir a rota padrão dele

    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : Controller
    {


        [HttpGet("id")]
        public Usuario BuscarPorId()  //busca no campo por id e retorna os dados
        {
            return new Usuario 
            {
                UsuarioID = 1
            };
        }



        [HttpGet("nome")]
        public Usuario BuscarPorNome(  [FromQuery] string nomeBuscado ) //busca no campo por nome e retorna os dados
        {
            return new Usuario
            {
                UsuarioID = 2
            };
        }


        [HttpGet("email")]
        public Usuario BuscarPorEmail()  //Busca no banco pelo email e retorna os dados
        {   
            return new Usuario
            {
                UsuarioID = 3
            };
        }


    }
}
