using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SystemTest.BLL.Servicios.Contrato;
using SystemTest.DTO;
using SystemTest.API.Utilidad;

namespace SystemTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServicesService _servicesService;

        public ServiceController(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var response = new Response<List<ServicioDTO>>();

            try
            {
                response.Status = true;
                response.Value = await _servicesService.Lista();
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
        public async Task<IActionResult> Crear([FromBody]ServicioDTO servicio)
        {
            var response = new Response<ServicioDTO>();

            try
            {
                response.Status = true;
                response.Value = await _servicesService.Crear(servicio);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.msg = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] ServicioDTO servicio)
        {
            var response = new Response<bool>();

            try
            {
                response.Status = true;
                response.Value = await _servicesService.Editar(servicio);
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
                response.Value = await _servicesService.Eliminar(id);
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
