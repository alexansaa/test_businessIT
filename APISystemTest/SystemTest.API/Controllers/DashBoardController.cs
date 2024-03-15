using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SystemTest.BLL.Servicios.Contrato;
using SystemTest.DTO;
using SystemTest.API.Utilidad;

namespace SystemTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private readonly IDashBoardService _service;

        public DashBoardController(IDashBoardService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Resumen")]
        public async Task<IActionResult> Resumen()
        {
            var response = new Response<DashBoardDTO>();

            try
            {
                response.Status = true;
                response.Value = await _service.Resumen();
            }
            catch(Exception ex)
            {
                response.Status = false;
                response.msg = ex.Message;
            }
            return Ok(response);
        }
    }
}
