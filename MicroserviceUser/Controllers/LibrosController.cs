﻿using MicroserviceUser.Data;
using MicroserviceUser.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceUser.Controllers
{
    public class LibrosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public LibrosController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Libro> listLibros = _context.Libro;
            return View(listLibros);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libro);
                _context.SaveChanges();
                TempData["Mensaje"] = "Guardado exitosamente";
                return RedirectToAction("index");
            }
            return View();
        }



        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var libro = _context.Libro.Find(id);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }
        [HttpPost]
        public IActionResult Edit(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Libro.Update(libro);
                _context.SaveChanges();
                TempData["Mensaje"] = "Actualizado exitosamente";

                return RedirectToAction("index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var libro = _context.Libro.Find(id);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        [HttpPost]
        public IActionResult DeleteLibro(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var libro = _context.Libro.Find(id);

            if (libro == null)
            {
                return NotFound();
            }
            _context.Libro.Remove(libro);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

    }
}
