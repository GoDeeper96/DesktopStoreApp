using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
namespace Entidades
{
    public class ArticuloxVenta:Base
    {
        public Articulo ar{get; set;}
        public Venta ven { get; set; }
        public List<ArticuloxVenta> av { get; set; }
        
        public ArticuloxVenta()
        {
            ar = new Articulo();
            ven = new Venta();
            av = new List<ArticuloxVenta>();

            //table_name = "dbo.Venta";
            server_name = @"SEBAS-PC\SQLEXPRESS";
            cadena_conexion = " Data Source = " + server_name +
                              " ; Initial Catalog = HoshiiDB" +
                              " ; Integrated Security =yes";
        }
        public void AgregarVenta(ArticuloxVenta nuevo)
        {
            if (!av.Exists(x => x.ar.cantidad.Equals(null)))
            {
                nuevo.ar.cantidad--;
                av.Add(nuevo);
            }
        }
        public  void ActualizarBD(List<ArticuloxVenta> lista)
        {
         
            List<ArticuloxVenta> listaModificados = lista.FindAll(x =>x.estadio == ESTADO.actualizado);
            using (SqlConnection connection = new SqlConnection(cadena_conexion))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Articulo SET cantidad = @cantidad Where codigo = @codigo";
                connection.Open();
                foreach (ArticuloxVenta a in listaModificados)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@cantidad", a.ar.cantidad);
                    command.ExecuteNonQuery();
                    connection.Close();
                }

            }

        }
    }
}
