using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUProyecto.Transactions
{
   public class AporteBLL
    {
        public static List<Aporte> List()
        {
            Entities db = new Entities();
            return db.Aporte.ToList();
        }
    }
}
