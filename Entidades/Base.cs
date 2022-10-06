using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum ESTADO { nuevo,antiguo,eliminado,actualizado,seleccionado }
    public class Base
    {
        public ESTADO estadio { get; set; }
        public string cadena_conexion { get; set; }
        public string server_name { get; set; }
        public string table_name { get; set; }
    }
}
