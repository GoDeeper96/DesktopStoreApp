using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Venta:Base
    {
        public string metodopago { get; set; }
        public double monto { get; set; }
        public DateTime fechadecompra { get; set; }
        public long codigodecompra { get; set; }
    }
    public class ListaVentas:Base
    {
        public List<Venta> ventas { get; set; }
        public ListaVentas()
        {
            ventas = new List<Venta>();
        }

    }
}
