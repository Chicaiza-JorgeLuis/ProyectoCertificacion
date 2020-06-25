using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BEUProyecto;
using BEUProyecto.Transactions;

namespace Proyecto.Controllers
{
    public class EventosController : Controller
    {
        //private Entities db = new Entities();

        // GET: Eventos
        public ActionResult Index()
        {
            return View(EventoBLL.List());
        }

        // GET: Eventos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = EventoBLL.Get(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // GET: Eventos/Create
        public ActionResult Create()
        {
            ViewBag.idcategoria = new SelectList(CategoriaBLL.List(), "idcategoria", "nombre");
            return View();
        }

        // POST: Eventos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idevento,nombre,fecha_inicio,fecha_final,organizador,idcategoria")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                EventoBLL.Create(evento);
                return RedirectToAction("Index");
            }

            ViewBag.categoria = new SelectList(CategoriaBLL.List(), "idcategoria", "nombre", evento.idcategoria);
            return View(evento);
        }

        // GET: Eventos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           Evento evento = EventoBLL.Get(id);
            if (evento == null)
            {
                return HttpNotFound();
            }

            //ViewBag.idcategoria = new SelectList(db.Categoria, "idcategoria", "nombre", evento.idcategoria);
            ViewBag.idcategoria = new SelectList(CategoriaBLL.List(), "idcategoria", "nombre", evento.idcategoria);
            return View(evento);
        }

        // POST: Eventos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idevento,nombre,fecha_inicio,fecha_final,organizador,idcategoria")] Evento evento)
        {
            if (ModelState.IsValid)
            {
               EventoBLL.Update(evento);
                return RedirectToAction("Index");
            }
            // ViewBag.idcategoria = new SelectList(db.Categoria, "idcategoria", "nombre", evento.idcategoria);
            ViewBag.idcategoria = new SelectList(CategoriaBLL.List(), "idcategoria", "nombre", evento.idcategoria);
            return View(evento);
        }

        // GET: Eventos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Evento evento = db.Evento.Find(id);
            Evento evento = EventoBLL.Get(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // POST: Eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventoBLL.Delete(id);
            return RedirectToAction("Index");
        }

    
    }
}
