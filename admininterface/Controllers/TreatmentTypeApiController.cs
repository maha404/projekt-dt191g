using admininterface.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Namespace
{
    [Route("api/treatmenttypes")]
    [ApiController]
    public class TreatmentTypeApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TreatmentTypeApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // GET: api/treatmenttype
        // Get all treatment types
        [HttpGet]
        public async Task<IActionResult> GetTreatmentTypes()
        {

            if(_context.TreatmentTypes == null)
            {
                return NotFound();
            }

            return Ok(await _context.TreatmentTypes.ToListAsync());
        }
    }
}
