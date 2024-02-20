using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrestamoController : Controller
    {
        [HttpPost]
        public IActionResult AgregarPrestamo([FromBody] ML.Prestamo prestamo)
        {
            if (prestamo == null)
            {
                return BadRequest(new { mensaje = "Datos de préstamo no proporcionados correctamente."});
            }

            if (BL.Prestamo.Add(prestamo))
            {
                return Ok(new { mensaje = "Prestamo agregado exitosamente." });
            } else
            {
                return BadRequest(new { mensaje = "Algo salio mal" });
            }          
        }


            [HttpPut("{id}")]
            public IActionResult ActualizarPrestamo(int id, [FromBody] ML.Prestamo prestamo)
            {
                if (prestamo == null)
                {
                    return BadRequest(new { mensaje = "Datos de préstamo no proporcionados correctamente." });
                }

                prestamo.Id = id; // Se Asigna el Id del Prestamo que se Actualizará

                if (BL.Prestamo.Update(prestamo))
                {
                    return Ok(new { mensaje = "Prestamo actualizado exitosamente." });
                }
                else
                {
                    return NotFound(new { mensaje = "No se encontró el prestamo a actualizar." });
                }
            }

        [HttpDelete("{id}")]
        public IActionResult EliminarPrestamo(int id)
        {
            if (BL.Prestamo.Delete(id))
            {
                return Ok(new { mensaje = "Prestamo eliminado exitosamente." });
            }
            else
            {
                return NotFound(new { mensaje = "No se encontró el prestamo a eliminar." });
            }
        }


        [HttpGet]
            public IActionResult ObtenerTodosLosPrestamos()
            {
                List<ML.Prestamo> prestamos = BL.Prestamo.GetAll();

                if (prestamos != null)
                {
                    return Ok(prestamos);
                }
                else
                {
                    return BadRequest(new { mensaje = "Error al obtener la lista de préstamos." });
                }
            }
        
    }
}
