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
    public class RegistrosController : Controller
    {
       // private Entities db = new Entities();

        // GET: Registros
        public ActionResult Index()
        {
            return View(RegistroBLL.List());
        }

        // GET: Registros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro registro = RegistroBLL.Get(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            return View(registro);
        }

        // GET: Registros/Create
        public ActionResult Create()
        {
            ViewBag.idaporte = new SelectList(AporteBLL.List(), "idaporte", "descripcion");
            ViewBag.idevento = new SelectList(EventoBLL.ListToNames(), "idevento", "nombre");
            ViewBag.idvoluntario = new SelectList(VoluntarioBLL.ListToNames(), "idvoluntario", "nombres");
            return View();
        }

        // POST: Registros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idregistro,idvoluntario,idaporte,idevento")] Registro registro)
        {
            if (ModelState.IsValid)
            {
               RegistroBLL.Create(registro);
                return RedirectToAction("Index");
            }

            ViewBag.idaporte = new SelectList(AporteBLL.List(), "idaporte", "descripcion",registro.idaporte);
            ViewBag.idevento = new SelectList(EventoBLL.ListToNames(), "idevento", "nombre",registro.idevento);
            ViewBag.idvoluntario = new SelectList(VoluntarioBLL.ListToNames(), "idvoluntario", "nombres",registro.idvoluntario);
            return View(registro);



   
        }

        // GET: Registros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           Registro registro = RegistroBLL.Get(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            ViewBag.idaporte = new SelectList(AporteBLL.List(), "idaporte", "descripcion", registro.idaporte);
            ViewBag.idevento = new SelectList(EventoBLL.ListToNames(), "idevento", "nombre", registro.idevento);
            ViewBag.idvoluntario = new SelectList(VoluntarioBLL.ListToNames(), "idvoluntario", "nombres", registro.idvoluntario);
            return View(registro);
        }

        // POST: Registros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idregistro,idvoluntario,idaporte,idevento")] Registro registro)
        {
            if (ModelState.IsValid)
            {
               RegistroBLL.Update(registro);
                return RedirectToAction("Index");
            }
            ViewBag.idaporte = new SelectList(AporteBLL.List(), "idaporte", "descripcion", registro.idaporte);
            ViewBag.idevento = new SelectList(EventoBLL.ListToNames(), "idevento", "nombre", registro.idevento);
            ViewBag.idvoluntario = new SelectList(VoluntarioBLL.ListToNames(), "idvoluntario", "nombres", registro.idvoluntario);
            return View(registro);
        }

        // GET: Registros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro registro = RegistroBLL.Get(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            return View(registro);
        }

        // POST: Registros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistroBLL.Delete(id);
            return RedirectToAction("Index");
        }

      
    }
}
