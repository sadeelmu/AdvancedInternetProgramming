using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    public class DoctorProfilesController : Controller
    {
        private readonly ProjectContext _context;

        public DoctorProfilesController(ProjectContext context)
        {
            _context = context;
        }

        // GET: DoctorProfiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.DoctorProfile.ToListAsync());
        }

        // GET: DoctorProfiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DoctorProfile == null)
            {
                return NotFound();
            }

            var doctorProfile = await _context.DoctorProfile
                .FirstOrDefaultAsync(m => m.DoctorId == id);
            if (doctorProfile == null)
            {
                return NotFound();
            }

            return View(doctorProfile);
        }

        // GET: DoctorProfiles/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: DoctorProfiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoctorId,Name,Age,Specialization,DoctorImage,PhoneNumber,Email")] DoctorProfile doctorProfile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string name = "drs";
                    if (!doctorProfile.Email.ToLower().EndsWith("@helpinghands.com"))
                    {

                        throw new Exception("Dr Email is outside your organization, Email must End with '@helpinghands.com'");
                    }

                    _context.Add(doctorProfile);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
              
                return View(doctorProfile);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel()); // returns the Error view page
            }
        }

        // GET: DoctorProfiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DoctorProfile == null)
            {
                return NotFound();
            }

            var doctorProfile = await _context.DoctorProfile.FindAsync(id);
            if (doctorProfile == null)
            {
                return NotFound();
            }
            return View(doctorProfile);
        }

        // POST: DoctorProfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DoctorId,Name,Age,Specialization,DoctorImage,PhoneNumber,Email")] DoctorProfile doctorProfile)
        {
            if (id != doctorProfile.DoctorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctorProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorProfileExists(doctorProfile.DoctorId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(doctorProfile);
        }

        // GET: DoctorProfiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DoctorProfile == null)
            {
                return NotFound();
            }

            var doctorProfile = await _context.DoctorProfile
                .FirstOrDefaultAsync(m => m.DoctorId == id);
            if (doctorProfile == null)
            {
                return NotFound();
            }

            return View(doctorProfile);
        }

        // POST: DoctorProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DoctorProfile == null)
            {
                return Problem("Entity set 'ProjectContext.DoctorProfile'  is null.");
            }
            var doctorProfile = await _context.DoctorProfile.FindAsync(id);
            if (doctorProfile != null)
            {
                _context.DoctorProfile.Remove(doctorProfile);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorProfileExists(int id)
        {
            return _context.DoctorProfile.Any(e => e.DoctorId == id);
        }
    }
}
