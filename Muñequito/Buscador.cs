using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Entidades;
namespace Muñequito
{
    public partial class Buscador : Form
    {
        public ListaArticulo lart;
        public string usuario;
        public Buscador(string usuario)
        {
            InitializeComponent();
            lart = new ListaArticulo();
            this.usuario = usuario;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lart.autocompletar(textBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (lart.buscar(textBox1.Text)||lart.buscar(comboBox4.Text)||comboBox3.Text!=null)
            {
                DetalleArticulo art = new DetalleArticulo(lart, textBox1.Text,
                                                               comboBox3.Text,
                                                               comboBox4.Text);
                art.ShowDialog();
            }
        }

        private void btnCrearArticulo_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
       
        private void BtnCrearArticulo_Click_1(object sender, EventArgs e)
        {
            Random r = new Random();           
            Articulo nuevo = new Articulo();
            nuevo.nombreArticulo = textBox2.Text;
            nuevo.precio = Convert.ToDouble(textBox3.Text);
            nuevo.nombreReferencial = textBox4.Text;
            nuevo.categoria = comboBox5.Text;
            nuevo.imagen = pictureBox1.Image;
            nuevo.codigo = r.Next(0, 10000);
            nuevo.cantidad = Convert.ToInt16(textBox6.Text);
            nuevo.ruta = textBox5.Text;
            nuevo.fecha = DateTime.Now;
            nuevo.autor = usuario;
            nuevo.estadio = ESTADO.antiguo;
            lart.InsertarDatos(nuevo);
            nuevo.estadio = ESTADO.nuevo;
            lart.Update(lart.lista_de_articulos);
            nuevo.estadio = ESTADO.antiguo;
            Action<Control.ControlCollection> func = null;
            func = (controls) =>
                         {
                             foreach (Control control in controls)
                                 if (control is TextBox)
                                     (control as TextBox).Clear();
                                 else
                                 func(control.Controls);
                         };
            func(Controls);
            pictureBox1.Refresh();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg;*.jpeg;*.gif;*.bmp;)|*.jpg;*.jpeg;*.gif;*.bmp;";
            
            if (open.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = open.FileName;
                pictureBox1.Image = new Bitmap(open.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Size = new Size(100, 100);
                File.Copy(textBox5.Text, Path.Combine(@"\Muñequito\Entidades\Imagenes\", Path.GetFileName(textBox5.Text)),true);
                
            }
        }
    }
}
