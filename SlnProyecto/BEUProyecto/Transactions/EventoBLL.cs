using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUProyecto.Transactions
{
   public class EventoBLL
    {

        public static void Create(Evento e)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Evento.Add(e);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static Evento Get(int? id)
        {
            Entities db = new Entities();
            return db.Evento.Find(id);
        }

        public static void Update(Evento Evento)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Evento.Attach(Evento);
                        db.Entry(Evento).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static void Delete(int? id)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Evento Evento = db.Evento.Find(id);
                        db.Entry(Evento).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static List<Evento> List()
        {
            Entities db = new Entities();
            return db.Evento.ToList();
        }

        public static List<Evento> ListToNames()
        {
            Entities db = new Entities();
            List<Evento> result = new List<Evento>();
            db.Evento.ToList().ForEach(x =>
                result.Add(
                    new Evento
                    {
                        nombre =x.nombre,
                        idevento= x.idevento
                    }));
            return result;
        }
    }
}
