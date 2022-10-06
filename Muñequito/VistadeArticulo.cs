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
    public partial class VistadeArticulo : Form
    {
        public ListaArticulo lart;
        public string tixt;
        public Articulo seleccionado;
        public VistadeArticulo(ListaArticulo lart,string tixt)
        {
            InitializeComponent();
            
            this.lart = lart;
            this.tixt = tixt;
        }

        private void VistadeArticulo_Load(object sender, EventArgs e)
        {
            seleccionado = lart.lista_de_articulos.Find(x => x.nombreReferencial.Equals(tixt));
            label6.Text = seleccionado.nombreReferencial;
            label10.Text = seleccionado.categoria;
            label3.Text = seleccionado.nombreArticulo;
            label9.Text = seleccionado.cantidad.ToString();
            label11.Text = seleccionado.precio.ToString();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = seleccionado.imagen;
            
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnComprar_Click(object sender, EventArgs e)
        {
           
            Compra1 c1 = new Compra1(lart,seleccionado.codigo);
            c1.ShowDialog();
        }
    }
}
