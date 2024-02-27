using System.Data.Entity;
using admininterface.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/treatmenttype")]
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
