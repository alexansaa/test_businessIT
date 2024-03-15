using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SystemTest.BLL.Servicios.Contrato;
using SystemTest.DTO;
using SystemTest.API.Utilidad;

namespace SystemTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IClientService _clientService;

        public UserController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var response = new Response<List<ClienteDTO>>();

            try
            {
                response.Status = true;
                response.Value = await _clientService.Lista();
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.msg = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("Crear")]
        public async Task<IActionResult> Crear([FromBody]ClienteDTO cliente)
        {
            var response = new Response<ClienteDTO>();

            try
            {
                response.Status = true;
                response.Value = await _clientService.Crear(cliente);
            }
            catch(Exception ex)
            {
                response.Status = false;
                response.msg = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] ClienteDTO cliente)
        {
            var response = new Response<bool>();

            try
            {
                response.Status = true;
                response.Value = await _clientService.Editar(cliente);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.msg = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var response = new Response<bool>();

            try
            {
                response.Status = true;
                response.Value = await _clientService.Eliminar(id);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.msg = ex.Message;
            }
            return Ok(response);
        }
    }
}
