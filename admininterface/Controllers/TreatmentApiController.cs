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

        // GET: api/treatments/with-type
        [HttpGet("with-type")]
        public async Task<IActionResult> GetTreatmentsWithType() 
        {
            var treatmentsWithTypeName = await _context.Treatments
                .Include(t => t.TreatmentType)
                .Select(t => new 
                {
                    t.Id,
                    t.Name,
                    t.Description,
                    t.TreatmentTime,
                    t.Price,
                    t.TreatmentTypeId,
                    TreatmentTypeName = t.TreatmentType.Name
                })
                .ToListAsync();

            if(treatmentsWithTypeName == null || !treatmentsWithTypeName.Any())
            {
                return NotFound();
            }

            return Ok(treatmentsWithTypeName);
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
