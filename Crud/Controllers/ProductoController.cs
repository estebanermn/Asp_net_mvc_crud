using Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud.Controllers
{
    public class ProductoController : Controller
    {
        private db_lafinaEntities db = new db_lafinaEntities();
        // GET: Producto
        public ActionResult index()
        {
            try
            {
                return View(db.productos.ToList());
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
        public ActionResult create(productos p)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                db.productos.Add(p);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al registrar producto. ", ex.Message);
                return View();
            }
        }

        public ActionResult listaMarca()
        {
            return PartialView(db.marcas.ToList());
        }

        public ActionResult listaCategoria()
        {
            return PartialView(db.categorias.ToList());
        }

        //public ActionResult listaProveedor()
        //{
        //    return PartialView(db.p.ToList());
        //}

        public ActionResult edit(int id)
        {
            try
            {
                productos producto = db.productos.Find(id);
                return View(producto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al encontrar producto." + id, ex.Message);
                return View();
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult edit(productos p)
        {
            try
            {
                productos productos = db.productos.Find(p.productoId);

                productos.marcaId = p.marcaId;
                productos.categoriaId = p.categoriaId;
                productos.proveedorId = p.proveedorId;
                productos.nombre = p.nombre;
                productos.descripcion = p.descripcion;
                productos.precio = p.precio;
                productos.stock = p.stock;
                productos.volumen = p.volumen;
                productos.tipo = p.tipo;
                productos.estado = p.estado;
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
            productos productos = db.productos.Find(id);  
            return View(productos);
        }


    }


}
