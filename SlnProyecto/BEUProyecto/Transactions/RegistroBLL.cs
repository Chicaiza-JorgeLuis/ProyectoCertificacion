using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUProyecto.Transactions
{
    public class RegistroBLL
    {
        public static void Create(Registro r)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                     
                        Config(r);
                        db.Registro.Add(r);
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

        private static void Config(Registro r)
        {
            r.fecha = DateTime.Now;
            r.estado = "Realizado"; //Creada
         
        }

        public static Registro Get(int? id)
        {
            Entities db = new Entities();
            return db.Registro.Find(id);
        }

        public static void Update(Registro Registro)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                       
                        Config(Registro);
                        db.Registro.Attach(Registro);
                        db.Entry(Registro).State = System.Data.Entity.EntityState.Modified;
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
                        Registro Registro= db.Registro.Find(id);
                        db.Entry(Registro).State = System.Data.Entity.EntityState.Deleted;
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

        public static List<Registro> List()
        {
            Entities db = new Entities();
            return db.Registro.ToList();
        }
    }
}
