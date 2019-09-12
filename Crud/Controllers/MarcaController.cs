using Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud.Controllers
{
    public class MarcaController : Controller
    {
        // GET: Marca
        private db_lafinaEntities db = new db_lafinaEntities();
        public ActionResult index()
        {
            try
            {
                //using (var db = new db_lafinaEntities() )
                //{
                //    //List<marcas> lista = db.marcas.Where(m >= m.nombre > 10).ToList();
                //    //return View(lista);
                //    return View(db.marcas.ToList());
                //}
                return View(db.marcas.ToList());
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
        public ActionResult create(marcas m)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                db.marcas.Add(m);
                db.SaveChanges();
                return RedirectToAction("index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al registra marca - ", ex.Message);
                return View();

            }


        }

        public ActionResult edit(int id)
        {
            marcas marca = db.marcas.Find(id);
            return View(marca);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult edit(marcas m)
        {

            try
            {
                marcas marca = db.marcas.Find(m.marcaId);
                marca.nombre = m.nombre;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult details(int id)
        {
            marcas marca = db.marcas.Find(id);
            return View(marca);
        }

        public ActionResult delete(int id)
        {
            marcas marca = db.marcas.Find(id);
            db.marcas.Remove(marca);
            db.SaveChanges();
            return RedirectToAction("index");
        }





    }
}