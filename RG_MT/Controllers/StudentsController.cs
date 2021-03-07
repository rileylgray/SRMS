using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG_MT.Data;
using RG_MT.Models;

namespace RG_MT.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SRMSContext _context;

        public StudentsController(SRMSContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var student = await _context.Students.FirstOrDefaultAsync(m => m.Id == id);
            var student = await _context.Students
                .Include(s => s.Courses).FirstOrDefaultAsync(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,BirthDay")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,BirthDay")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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
            return View(student);
        }

        public IActionResult EnrolledCoursesEdit(int? id)
        {
            if (id == null)
                return NotFound();

            var student = _context.Students
                .Include(s => s.Courses).FirstOrDefault(s => s.Id == id);

            if (student == null)
                return NotFound();

            StudentsCourses enrolled = new StudentsCourses();
            enrolled.student = student;

            List<Course> Courses = _context.Courses.ToList();

            foreach(Course course in Courses)
            {
                EnrolledClass ec = new EnrolledClass();
                ec.Id = course.Id;
                ec.courseCode = course.CourseNumber;
                ec.courseName = course.CourseTitle;
                ec.CourseCredits = course.Credits;
                ec.isEnrolled = student.Courses.Contains(course);

                enrolled.EnrolledClasses.Add(ec);
            }
            return View(enrolled);
        }



        [HttpPost]
        public IActionResult EnrolledCoursesEdit(StudentsCourses sc)
        {
            Student student = _context.Students
                .Include(s => s.Courses).FirstOrDefault(s => s.Id == sc.student.Id);
            _context.Update(student);
            student.Courses.Clear();

            foreach(EnrolledClass ec in sc.EnrolledClasses)
            {
                if (ec.isEnrolled)
                {
                    Course course = _context.Courses.Find(ec.Id);
                    student.Courses.Add(course);
                }
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
