using System.Data.Entity;
using admininterface.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/treatments")]
    [ApiController]
    public class TreatmentApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TreatmentApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/treatments
        // Get all treatments
        [HttpGet]
        public async Task<IActionResult> GetTreatment() 
        {

            if(_context.Treatments == null)
            {
                return NotFound();
            }

            return Ok(await _context.Treatments.ToListAsync());
        }
        
    }
}
