using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCPrototipo.Models;

namespace MVCPrototipo.Controllers
{
    public class InstructorController : Controller
    {
        private static List<Instructor> instructors = new List<Instructor>();
      
        // GET: Instructor
        public IActionResult Index()
        {
            return View( instructors);
        }

        // GET: Instructor/Details/5
        public IActionResult Details(int id)
        {
            if (instructors[id] != null)
            {
                return View(instructors[id]);
            }

            return NotFound(); 
        }

        // GET: Instructor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instructor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("InstructorId,Nombre,Apellidos,Grado,FotoPerfil")] Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                instructors.Add(instructor);
                return RedirectToAction(nameof(Index));
            }
            return View(instructor);
        }

        // GET: Instructor/Edit/5
        public IActionResult Edit(int id)
        {
            if (instructors[id] == null)
            {
                return NotFound();
            }
            return View(instructors[id]);
        }

        // POST: Instructor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("InstructorId,Nombre,Apellidos,Grado,FotoPerfil")] Instructor instructor)
        {
          
            if (ModelState.IsValid)
            {
                try
                {
                    instructors.Add(instructor);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstructorExists(id))
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
            return View(instructor);
        }

        // GET: Instructor/Delete/5
        public IActionResult Delete(int id)
        {
            // instructors.RemoveAt(id);
            if (instructors == null)
            {
                return NotFound();
            }

            return View(instructors[id]);
        }

        // POST: Instructor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            instructors.RemoveAt(id);

            return RedirectToAction(nameof(Index));

        }

        private bool InstructorExists(int id)
        {
            if (instructors[id] != null)
                return true;
            else
                return false;
        }
    }
}
