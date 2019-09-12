using Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud.Controllers
{
    public class CategoriaController : Controller
    {
        private db_lafinaEntities db = new db_lafinaEntities();
        // GET: Categoria
        public ActionResult index()
        {
            try
            {
                return View(db.categorias.ToList());
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult create(categorias c)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                db.categorias.Add(c);
                db.SaveChanges();
                return RedirectToAction("index");


            }
            catch (Exception ex)
            {

                ModelState.AddModelError("Error al registrar categoría - ", ex.Message);
                return View();
            }
        }

        public ActionResult edit(int id)
        {
            categorias categoria = db.categorias.Find(id);
            return View(categoria);
        }

        [HttpPost]
        public ActionResult edit(categorias cat)
        {
            categorias categorias = db.categorias.Find(cat.categoriaId);
            categorias.nombre = cat.nombre;
            categorias.descripcion = cat.descripcion;
            categorias.estado = cat.estado;

            db.SaveChanges();

            return RedirectToAction("index");
        }

        public ActionResult details(int id)
        {
            categorias categoria = db.categorias.Find(id);
            return View(categoria);
        }

        public ActionResult delete(int id)
        {
            categorias categoria = db.categorias.Find(id);
            db.categorias.Remove(categoria);
            db.SaveChanges();
            return RedirectToAction("index");
        }


    }
}