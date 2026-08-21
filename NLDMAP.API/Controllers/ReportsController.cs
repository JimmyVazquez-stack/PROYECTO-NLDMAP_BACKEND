using Microsoft.AspNetCore.Mvc;
using NLDMAP.Application.DTOs;
using NLDMAP.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace NLDMAP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        //variable de solo lectura para repositorio
        private readonly IReportRepository _reportRepository;
        
        //Inyeccion de dependencias en el constructor
        public ReportsController(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        

        //get : api/reports/map-points
        [HttpGet("map-points")]
        public ActionResult<IEnumerable<MapPointResponse>> GetMapPoints()
        {

            return Ok(new List<MapPointResponse>());
        }

        //Post: api/reports
        //endpoint que recibe datos reales de flutter
        [HttpPost]
        public async Task<IActionResult> CreateReport([FromBody] CreateReportRequest request)
        {
            //validacion
            if (string.IsNullOrEmpty(request.MissingPersonName) ||
                request.LastSightingLatitude == 0 ||
                request.LastSightingLongitude == 0)
            {
                return BadRequest(new
                {
                    Exito = false,
                    Mensaje = "Faltan datos del nucleo minimo."
                });
            }

            //Generar el folio unico del reporte
            var nuevoFolio = Guid.NewGuid();
            
            //Delegar responsabilidad de guardar
            await _reportRepository.SaveReportAsync(nuevoFolio, request);

            //responder a flutter 
            return Ok(new
            {
                Exito= true,
                Mensaje = "Reporte creado exitosamente.",
                Folio = nuevoFolio
            });
        }
    }
}