using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
namespace Muñequito
{
    public partial class Compra1 : Form
    {
        public ListaArticulo lart;
       
        public string metodo;
        public double cantidad;
        public double total;
        public long codigo;
        public Compra1(ListaArticulo lart,long codigo)
        {
            InitializeComponent();
            this.lart = lart;
            this.codigo = codigo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if(radioButton1.Checked==true)
            {
                metodo = radioButton1.Text;
            }
            if(radioButton2.Checked==true)
            {
                metodo = radioButton2.Text;
            }
            
            
            
        }

        private void Compra1_Load(object sender, EventArgs e)
        {
            label6.Text = lart.lista_de_articulos.Find(x => x.codigo.Equals(codigo)).nombreReferencial;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = lart.lista_de_articulos.Find(x => x.codigo.Equals(codigo)).cantidad.ToString();
            //total = lart.lista_de_articulos.Find(x=>x.codigo.Equals(codigo)).
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ArticuloxVenta axv = new ArticuloxVenta();
            //ListaVentas lv = new ListaVentas();
            //textBox2.Text = (lart.lista_de_articulos.Find(x => x.codigo.Equals(codigo)).cantidad * lart.lista_de_articulos.Find(x => x.codigo.Equals(codigo)).precio).ToString();
            //axv.AgregarVenta();
        }
    }
}
