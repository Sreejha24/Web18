using Entityinmvc.Data;
using Entityinmvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Entityinmvc.Controllers
{
    public class PersonalDetailController : Controller
    {

        private readonly ApplicationDbContext _context;

        public PersonalDetailController(ApplicationDbContext context)
        {
            _context = context;
        }




        //public async Task<IActionResult> Edit(int? id,PersonalDetail personalDetail)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        _context.PersonalDetails.Add(personalDetail);
        //        _context.SaveChanges();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(personalDetail);
        //}

        // GET: PersonalDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalDetail = await _context.PersonalDetails.FindAsync(id);
            if (personalDetail == null)
            {
                return NotFound();
            }
            return View(personalDetail);
        }


        // POST: PersonalDetails/Edit/5
        // To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("PersonID,FirstName,LastName,Email,Mobile")] PersonalDetail personalDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(personalDetail).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personalDetail);
        }
        // GET: Employee
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonalDetails.ToListAsync());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            PersonalDetail personDetails = _context.PersonalDetails.Find(id);
            if (personDetails == null)
            {
                return NotFound();
            }
            return View(personDetails);

        }


        // GET: Employee/Create
        public IActionResult create(int id = 0)
        {
            if (id == 0)
                return View(new PersonalDetail());
            else
                return View(_context.PersonalDetails.Find(id));
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> create([Bind("PersonID,FirstName,LastName,Email,Mobile")] PersonalDetail personalDetail)
        {
            if (ModelState.IsValid)
            {
                if (personalDetail.PersonID == 0)
                    _context.Add(personalDetail);
                else
                    _context.Update(personalDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personalDetail);
        }


        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var personalDetail = await _context.PersonalDetails.FindAsync(id);
            _context.PersonalDetails.Remove(personalDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



    }
}
