using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bitacora.API.Data;
using Microsoft.EntityFrameworkCore;
using bitacora.API.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace bitacora.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ActividadController : ControllerBase 
    {
        private readonly DataContext _context;
        public ActividadController(DataContext context){
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actividad>>> GetActividades(){
            var actividades = await _context.Actividades.Include(q=> q.Category).ToListAsync();
            return Ok(actividades);
            
        }
        
         [HttpGet("byId/{id}")]
        public async Task<ActionResult<Actividad>> GetByDate(int  id)
        {

            var actividades = await _context.Actividades.Include(p=>p.Category).FirstOrDefaultAsync(q=> q.id==id);

            if (actividades == null)
            {
                return NotFound();
            }
            return actividades;
        }

         [HttpGet("{horaInicio}")]
        public async Task<ActionResult<IEnumerable<Actividad>>> GetByDate(DateTime  horaInicio)
        {

            var actividades = await _context.Actividades .Where(q=> q.horaInicio==horaInicio).Include(p=>p.Category).ToListAsync();

            if (actividades == null)
            {
                return NotFound();
            }
            return actividades;
        }

        [HttpGet("{rangoFechaInicio}/{rangoFechaFinal}")]
        public async Task<ActionResult<IEnumerable<Actividad>>> GetByRange(DateTime  rangoFechaInicio, DateTime rangoFechaFinal)
        {

            var actividades = await _context.Actividades.Where(q=> q.horaInicio>=rangoFechaInicio && q.horaInicio<=rangoFechaFinal).Include(p=>p.Category).ToListAsync();

            if (actividades == null)
            {
                return NotFound();
            }
            return actividades;
        }


        [HttpPost]
        public async Task<ActionResult<Actividad>>PostActividad(Actividad item)
        {
            _context.Actividades.Add(item);
            await _context.SaveChangesAsync();
            return item;

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActividad(int id, Actividad item)
        {
            if (id != item.id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

      





}
}