using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoctorAPI.Data;
using Project.Models;

namespace DoctorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorProfilesController : ControllerBase
    {
        private readonly DoctorAPIContext _context;

        public DoctorProfilesController(DoctorAPIContext context)
        {
            _context = context;
        }

        // GET: api/DoctorProfiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorProfile>>> GetDoctorProfile()
        {
          if (_context.DoctorProfile == null)
          {
              return NotFound();
          }
            return await _context.DoctorProfile.ToListAsync();
        }

        // GET: api/DoctorProfiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorProfile>> GetDoctorProfile(int id)
        {
          if (_context.DoctorProfile == null)
          {
              return NotFound();
          }
            var doctorProfile = await _context.DoctorProfile.FindAsync(id);

            if (doctorProfile == null)
            {
                return NotFound();
            }

            return doctorProfile;
        }

        // PUT: api/DoctorProfiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctorProfile(int id, DoctorProfile doctorProfile)
        {
            if (id != doctorProfile.DoctorId)
            {
                return BadRequest();
            }

            _context.Entry(doctorProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorProfileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DoctorProfiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DoctorProfile>> PostDoctorProfile(DoctorProfile doctorProfile)
        {
          if (_context.DoctorProfile == null)
          {
              return Problem("Entity set 'DoctorAPIContext.DoctorProfile'  is null.");
          }
            _context.DoctorProfile.Add(doctorProfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoctorProfile", new { id = doctorProfile.DoctorId }, doctorProfile);
        }

        // DELETE: api/DoctorProfiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctorProfile(int id)
        {
            if (_context.DoctorProfile == null)
            {
                return NotFound();
            }
            var doctorProfile = await _context.DoctorProfile.FindAsync(id);
            if (doctorProfile == null)
            {
                return NotFound();
            }

            _context.DoctorProfile.Remove(doctorProfile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoctorProfileExists(int id)
        {
            return (_context.DoctorProfile?.Any(e => e.DoctorId == id)).GetValueOrDefault();
        }
    }
}
