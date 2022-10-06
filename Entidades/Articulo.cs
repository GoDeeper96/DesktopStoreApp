using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    public class Articulo:Base
    {
        public string nombreReferencial { get; set; }
        public string nombreArticulo { get; set; }
        public double precio { get; set; }
        public long codigo { get; set; }
        public DateTime fecha { get; set; }
        public string categoria { get; set; }
        public bool stock { get; set; }
        public string autor { get; set; }
        public int cantidad { get; set; }
        public string[] descripcion { get; set; }
        public Image imagen{get; set;}
        public List<Label> lb { get; set; }
        public string ruta { get; set; }
        
        public Articulo()
        {
            lb = new List<Label>();
           
        }
       
    }
    public class ListaArticulo:Base
    {
        public List<Articulo> lista_de_articulos { get; set; }
        public List<String> cadena { get; set; }
        public ImageList imagenes { get; set; }
        
        public ListaArticulo()
        {     
            imagenes = new ImageList();
            lista_de_articulos = new List<Articulo>();
            table_name = "dbo.Articulo";
            server_name = @"SEBAS-PC\SQLEXPRESS";
            cadena_conexion = " Data Source = " + server_name +
                              " ; Initial Catalog = HoshiiDB" +
                              " ; Integrated Security =yes";
            lista_de_articulos = LeerDb();          
        }
        public void InsertarDatos(Articulo nuevo)
        {
           
            if(!lista_de_articulos.Exists(x=>x.codigo.Equals(nuevo.codigo)))
            {
                lista_de_articulos.Add(nuevo);
                
                
            }

        }
        public void dibujar(Graphics p,ListaArticulo resultados,string found,string categoria,string precio,Panel po,bool btn,bool btn2,EventHandler eh)
        {
            int ancho = 100;
            int largo = 100;
            int indicex = 0;
            int indicey = 0;
            int espacio = 0;
            foreach (Articulo x in resultados.SeleccionGlobal(found, categoria, precio,btn,btn2))
            {
                if (indicex >= 0 && indicex < 3 && indicey == 0)
                {
                    indicey = 0;
                    p.DrawImage(x.imagen, indicex * ancho + espacio, indicey * largo, ancho, largo);
                    int count = 20;
                    foreach (Label lz in resultados.lsd(x.codigo))
                    {
                        
                        po.Controls.Add(lz);
                        lz.DoubleClick += new EventHandler(eh);
                        lz.AutoSize = true;
                        lz.Location = new Point(indicex * ancho + espacio + 120, count);
                        count += 15;
                        
                    }
                    indicex++;
                    espacio += 150;
                }
                if (indicex == 3)
                {
                    indicex = 0;
                    indicey++;
                    espacio = 0;
                }
                else if (indicey > 0)
                {

                    p.DrawImage(x.imagen, indicex * ancho + espacio, indicey * largo + 20, ancho, largo);
                    int count = 130;
                    foreach (Label lz in resultados.lsd(x.codigo))
                    {

                        po.Controls.Add(lz);
                        
                        lz.DoubleClick += new EventHandler(eh);
                        lz.AutoSize = true;
                        lz.Location = new Point(indicex * ancho + espacio + 120, count);
                        count += 15;
                    }
                    indicex++;
                    espacio += 150;
                }
            }
        }
      public void autocompletar(TextBox t1)
        {
            foreach(Articulo x in lista_de_articulos)
            {
                t1.AutoCompleteCustomSource.Add(x.categoria);
                t1.AutoCompleteCustomSource.Add(x.nombreReferencial);
                t1.AutoCompleteCustomSource.Add(x.nombreArticulo);
            }
        }
        public bool buscar(string texto)
        {
            return lista_de_articulos.Exists(x => x.nombreArticulo.Equals(texto)||
                                                  x.nombreReferencial.Equals(texto)||
                                                  x.categoria.Equals(texto));
        }
        public List<Articulo> SeleccionGlobal(string textbuscador,string categoria,string precio,bool btn,bool btn2)
        {
            //if (btn==false)
            

            List<Articulo> results = new List<Articulo>();
           
                if (categoria != "")
                {
                    results = lista_de_articulos.FindAll(
                        delegate (Articulo ar)
                        {
                            return ar.categoria.Equals(categoria);
                        }
                        );
                }
                if (precio != "")
                {
                    results = lista_de_articulos.FindAll(
                        delegate (Articulo ar)
                        {
                            if (precio == "0-50")
                            {
                                return ar.precio >= 0 && ar.precio <= 50;
                            }
                            else if (precio == "50-100")
                            {
                                return ar.precio >= 50 && ar.precio <= 100;
                            }
                            else if (precio == "100-300")
                            {
                                return ar.precio >= 100 && ar.precio <= 300;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    );
                }
                if (textbuscador != "" && precio == "")
                {
                    results = lista_de_articulos.FindAll(x => x.categoria.Equals(textbuscador) ||
                                                      x.nombreReferencial.Equals(textbuscador) ||
                                                      x.nombreArticulo.Equals(textbuscador));

                }
                if (categoria != "" && precio != "")
                {
                    results = lista_de_articulos.FindAll(
                        delegate (Articulo ar)
                        {
                            if (precio == "0-50")
                            {
                                return ar.precio >= 0 && ar.precio <= 50 && ar.categoria.Equals(categoria);
                            }
                            else if (precio == "50-100")
                            {
                                return ar.precio >= 50 && ar.precio <= 100 && ar.categoria.Equals(categoria);
                            }
                            else if (precio == "100-300")
                            {
                                return ar.categoria.Equals(categoria) && ar.precio >= 100 && ar.precio <= 300;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    );
                }
                if (categoria != "" && precio != "")
                {
                    results = lista_de_articulos.FindAll(
                        delegate (Articulo ar)
                        {
                            if (precio == "0-50")
                            {
                                return ar.precio >= 0 && ar.precio <= 50 && ar.categoria.Equals(categoria);
                            }
                            else if (precio == "50-100")
                            {
                                return ar.precio >= 50 && ar.precio <= 100 && ar.categoria.Equals(categoria);
                            }
                            else if (precio == "100-300")
                            {
                                return ar.precio >= 100 && ar.precio <= 300 && ar.categoria.Equals(categoria);
                            }
                            else
                            {
                                return false;
                            }
                        }
                    );
                }
                if (textbuscador != "")
                {
                    results = lista_de_articulos.FindAll(x => x.categoria.Equals(textbuscador) ||
                                                      x.nombreReferencial.Equals(textbuscador) ||
                                                      x.nombreArticulo.Equals(textbuscador));
                }
            if (btn == true)
                return results.OrderBy(x => x.precio).ToList();
            else if (btn2 == true)
                return results.OrderByDescending(x => x.precio).ToList();

            return results;
        }
        public ImageList llenarlistaImagenes()
        {

            foreach (Articulo x in lista_de_articulos)
            {
                imagenes.Images.Add(x.imagen);
            }
            imagenes.ImageSize= new Size(100, 100);
            return imagenes;
        }
        public List<Label> lsd(long codigo)
        {
            
              
            List<Label> labelz = lista_de_articulos.FindAll(x=> x.codigo.Equals(codigo)).SelectMany(x => x.lb).ToList();
            
            return labelz;
        }
       
        
        public List<Articulo> LeerDb()
        {
            List<Articulo> aux = new List<Articulo>();
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
                    Articulo objeto = new Articulo();
                    objeto.autor = dr["autor"].ToString();
                    objeto.precio = Convert.ToDouble(dr["precio"]);
                    objeto.nombreArticulo = dr["nombreArticulo"].ToString();
                    objeto.nombreReferencial = dr["nombreReferencial"].ToString();
                    objeto.categoria = dr["categoria"].ToString().Replace("    ","");
                    //objeto.categoria.Substring(objeto.categoria.Length, 5);
                    objeto.estadio = ESTADO.antiguo;
                    objeto.cantidad = Convert.ToInt16(dr["cantidad"]);
                    objeto.codigo = Convert.ToInt64(dr["codigo"]);
                    byte[] b = (byte[])dr["Imagen"];
                    MemoryStream mem = new MemoryStream(b);
                    objeto.imagen = Image.FromStream(mem);
                        objeto.lb.Add(new Label { Text = objeto.nombreReferencial });
                        objeto.lb.Add(new Label { Text = "Precio:S/" + objeto.precio });
                        objeto.lb.Add(new Label { Text = "Categoria:" + objeto.categoria });
                        objeto.lb.Add(new Label { Text = "Descripcion:" + objeto.descripcion });
                        objeto.lb.Add(new Label { Text = "Cantidad:" + objeto.cantidad });
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
        public byte[] path(string ruta)
        {
            
            byte[] path = File.ReadAllBytes(ruta);

            return path;
        }
        public void Update(List<Articulo> lista)
        {
            List<Articulo> _lista_nuevos = lista.FindAll(x => x.estadio == ESTADO.nuevo);
            
            //GRABAR NUEVOS
            SqlConnection sqlcon = new SqlConnection(cadena_conexion);
            try
            {
                string comando = " INSERT INTO " + table_name + "(nombreReferencial, nombreArticulo, precio, codigo, fecha, categoria, cantidad, autor, imagen) " +
                                 "  VALUES (@nombreReferencial, @nombreArticulo, @precio, @codigo, @fecha, @categoria, @cantidad, @autor, @imagen) " ;
                SqlCommand sqlcomando = new SqlCommand(comando, sqlcon);
                       
                sqlcon.Open();
                foreach (Articulo a in _lista_nuevos)
                {
                    sqlcomando.Parameters.Clear();
                    sqlcomando.Parameters.Add(new SqlParameter("@nombreReferencial", a.nombreReferencial));
                    sqlcomando.Parameters.Add(new SqlParameter("@nombreArticulo", a.nombreArticulo));
                    sqlcomando.Parameters.Add(new SqlParameter("@precio", a.precio));
                    sqlcomando.Parameters.Add(new SqlParameter("@codigo", a.codigo));
                    sqlcomando.Parameters.Add(new SqlParameter("@fecha", a.fecha));
                    sqlcomando.Parameters.Add(new SqlParameter("@categoria", a.categoria));
                    sqlcomando.Parameters.Add(new SqlParameter("@cantidad", a.cantidad));
                    sqlcomando.Parameters.Add(new SqlParameter("@autor", a.autor));
                    sqlcomando.Parameters.Add(new SqlParameter("@imagen", path(a.ruta)));                   
                    sqlcomando.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { }
            finally { sqlcon.Close(); }    
}
    }
}
