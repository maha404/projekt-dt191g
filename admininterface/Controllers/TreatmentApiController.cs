using admininterface.Data;
using admininterface.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        // GET api/treatments/id
        // Get specific treatment
        [HttpGet("{id}")]
        public async Task<ActionResult<TreatmentModel>> GetOneTreatment(int id)
        {
            var treatment = await _context.Treatments.FindAsync(id);

            if(treatment == null) 
            {
                return NotFound();
            }

            return treatment;
        }
    }
}
