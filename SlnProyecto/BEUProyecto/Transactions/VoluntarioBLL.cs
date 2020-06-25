using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUProyecto.Transactions
{
    public class VoluntarioBLL
    {
        public static void Create(Voluntario v)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Voluntario.Add(v);
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


        public static Voluntario Get(int? id)
        {
            Entities db = new Entities();
            return db.Voluntario.Find(id);
        }

        public static void Update(Voluntario voluntario)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Voluntario.Attach(voluntario);
                        db.Entry(voluntario).State = System.Data.Entity.EntityState.Modified;
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
                        Voluntario voluntario = db.Voluntario.Find(id);
                        db.Entry(voluntario).State = System.Data.Entity.EntityState.Deleted;
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


        public static List<Voluntario> List()
        {
            Entities db = new Entities();
            //Instancia del contexto

            /*List<Alumno> alumons = db.Alumnoes.ToList();
            List<Alumno> resultado = new List<Alumno>();
            foreach (Alumno a in alumons) {
                if (a.sexo == "M") {
                    resultado.Add(a);
                }
            }
            return resultado;*/
            //SQL -> SELECT * FROM dbo.Alumno WHERE sexo = 'M'
            //return db.Alumnoes.Where(x => x.sexo == "M").ToList();

            return db.Voluntario.ToList();

            //Los metodos del EntityFramework se denomina Linq, 
            //y la evluacion de condiciones lambda
        }


        public static List<Voluntario> ListToNames()
        {
            Entities db = new Entities();
            List<Voluntario> result = new List<Voluntario>();
            db.Voluntario.ToList().ForEach(x =>
                result.Add(
                    new Voluntario
                    {
                        nombres = x.nombres + " " + x.apellidos,
                        idvoluntario = x.idvoluntario
                    }));
            return result;
        }

        private static Voluntario GetVoluntario(string cedula)
        {
            Entities db = new Entities();
            return db.Voluntario.FirstOrDefault(x => x.cedula == cedula);
        }
    }
}
