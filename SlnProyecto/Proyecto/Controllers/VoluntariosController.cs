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
    public class VoluntariosController : Controller
    {
      //  private Entities db = new Entities();

        // GET: Voluntarios
        public ActionResult Index()
        {
            return View(VoluntarioBLL.List());
        }

        // GET: Voluntarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           Voluntario voluntario = VoluntarioBLL.Get(id);
            if (voluntario == null)
            {
                return HttpNotFound();
            }
            return View(voluntario);
        }

        // GET: Voluntarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Voluntarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idvoluntario,nombres,apellidos,cedula,telefono,fecha_nacimiento,direccion,sexo")] Voluntario voluntario)
        {
            if (ModelState.IsValid)
            {
                VoluntarioBLL.Create(voluntario);
                return RedirectToAction("Index");
            }

            return View(voluntario);
        }

        // GET: Voluntarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           Voluntario voluntario= VoluntarioBLL.Get(id);
            if (voluntario == null)
            {
                return HttpNotFound();
            }
            return View(voluntario);
        }

        // POST: Voluntarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idvoluntario,nombres,apellidos,cedula,telefono,fecha_nacimiento,direccion,sexo")] Voluntario voluntario)
        {
            if (ModelState.IsValid)
            {
                VoluntarioBLL.Update(voluntario);
                return RedirectToAction("Index");
            }
            return View(voluntario);
        }

        // GET: Voluntarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           Voluntario voluntario= VoluntarioBLL.Get(id);
            if (voluntario == null)
            {
                return HttpNotFound();
            }
            return View(voluntario);
        }

        // POST: Voluntarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VoluntarioBLL.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
