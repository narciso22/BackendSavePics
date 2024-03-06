using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using UDH = WebApplication1.Helpers.UserDataHelper;
using BC = BCrypt.Net.BCrypt;
namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController(SrvTrContext context) : ControllerBase
    {
        private readonly SrvTrContext _dbcontext = context;

        [HttpGet("Lista")]
        public IActionResult Lista() {
            List<User> lista = [.. _dbcontext.Users];
            return Ok(lista);
        }

        [HttpPost("Autenticar")]
        public IActionResult AutenticarUsr([FromBody] AuthUser request)
        {
            try
            {
                var usuario = UDH.ObtenerUsuario(_dbcontext, request.UserName);

                //if (usuario == null || !BC.Verify(request.Password, usuario.Password))
                //{

                //    return StatusCode(StatusCodes.Status401Unauthorized, "No se pudo autenticar");
                //}
                //else
                //{
                    return StatusCode(StatusCodes.Status200OK, (
                        new User
                        {
                            UserName = usuario.UserName,
                            ApellidoP = usuario.ApellidoP,
                            ApellidoM = usuario.ApellidoM
                        }
                      )
                    );
                //}
            }
            catch
            {
                return StatusCode(StatusCodes.Status303SeeOther, "Ocurrio un error");
            }
        }


    }
}
