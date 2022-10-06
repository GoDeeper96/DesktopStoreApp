using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
namespace Entidades
{
    public class Cliente:Base
    {
        public string nombre { get; set; }
        public string id { get; set; }
        public string contraseña { get; set; }
        public string correo { get; set; }
        public string alias { get; set; }
        

    }
    public class ListaClientes:Base
    {
        public List<Cliente> lista_de_clientes { get; set; }
       
        public ListaClientes()
        {
            lista_de_clientes = new List<Cliente>();
           
            table_name = "dbo.Cliente";
            server_name = @"SEBAS-PC\SQLEXPRESS";
            cadena_conexion = " Data Source = " + server_name +
                              " ; Initial Catalog = HoshiiDB" +
                              " ; Integrated Security =yes";
            lista_de_clientes = LeerDb();
        }
        public void InsertarDatos(Cliente nuevo)
        {
            if(!lista_de_clientes.Exists(x=>x.id.Equals(nuevo.id)&&
                                            x.correo.Equals(nuevo.correo)&&
                                            x.alias.Equals(nuevo.alias)))
            {
                lista_de_clientes.Add(nuevo);
                
            }
        }
        public bool ValidacionUsuario(string clave, string usuario)
        {
            Cliente us = new Cliente();
            
            return lista_de_clientes.Exists(x => x.id.Equals(usuario)&&x.contraseña.Equals(clave));
                    
           
        }
        public void Update(List<Cliente> lista)
        {
            List<Cliente> _lista_nuevos = lista.FindAll(x => x.estadio == ESTADO.nuevo);

            //GRABAR NUEVOS
            SqlConnection sqlcon = new SqlConnection(cadena_conexion);
            try
            {
                string comando = " INSERT INTO " + table_name + "(id, nombre, contraseña, correo, alias) " +
                                 "  VALUES (@id, @nombre, @contraseña, @correo, @alias) ";
                SqlCommand sqlcomando = new SqlCommand(comando, sqlcon);

                sqlcon.Open();
                foreach (Cliente a in _lista_nuevos)
                {
                    sqlcomando.Parameters.Clear();
                    sqlcomando.Parameters.Add(new SqlParameter("@id", a.id));
                    sqlcomando.Parameters.Add(new SqlParameter("@nombre", a.nombre));
                    sqlcomando.Parameters.Add(new SqlParameter("@contraseña", a.contraseña));
                    sqlcomando.Parameters.Add(new SqlParameter("@correo", a.correo));
                    sqlcomando.Parameters.Add(new SqlParameter("@alias", a.alias));
                    sqlcomando.ExecuteNonQuery();
                }
            }

            catch (Exception ex) { }
            finally { sqlcon.Close(); }
        }
            public List<Cliente> LeerDb()
        {
            List<Cliente> aux = new List<Cliente>();
            SqlConnection sqlcn = null;
            try
            {
                sqlcn = new SqlConnection(cadena_conexion);
                sqlcn.Open();
                string comando = " SELECT  *  FROM " + table_name;
                SqlCommand sqlcomand = new SqlCommand(comando, sqlcn);
                SqlDataReader dr = sqlcomand.ExecuteReader();
                while (dr.Read())
                {
                    Cliente objeto = new Cliente();
                    objeto.nombre = dr["nombre"].ToString();
                    objeto.alias = dr["alias"].ToString();
                    objeto.contraseña = dr["contraseña"].ToString();
                    objeto.estadio = ESTADO.antiguo;
                    objeto.correo = dr["correo"].ToString();
                    objeto.id = dr["id"].ToString();
                    aux.Add(objeto);
                }
            }
            catch (Exception ex) { }
            finally
            {
                

                sqlcn.Close();
            }
            return aux;
        }
    }
    

}


//public List<Cliente> LeeDatos()
//{
//    List<Cliente> aux = new List<Cliente>();
//    l_a = File.ReadAllLines("Lista de clientes registrados.TXT").ToList();
//    foreach(String s in l_a)
//    {
//        char[] separador = { ',' };
//        string[] cadena = s.Split(separador);
//        Cliente cliente = new Cliente();
//        cliente.nombre = (cadena[0]);
//        cliente.id = (cadena[1]);
//        cliente.correo = (cadena[2]);
//        cliente.contraseña = (cadena[3]);
//        cliente.alias = (cadena[4]);
//    }
//    return aux;
//}

//public void Grabar()
//{
//    //l_a = new List<string>();
//    foreach(Cliente c in lista_de_clientes)
//    {

//        StringBuilder sb = new StringBuilder();
//        sb.Append(c.nombre); sb.Append(",");
//        sb.Append(c.id); sb.Append(",");
//        sb.Append(c.correo); sb.Append(",");
//        sb.Append(c.contraseña); sb.Append(",");
//        sb.Append(c.alias); sb.Append(",");
//        l_a.Add(sb.ToString());
//    }
//    File.WriteAllLines("Datos.TXT", l_a, Encoding.UTF8);
//}