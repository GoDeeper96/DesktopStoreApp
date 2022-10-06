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
using System.IO;
namespace Muñequito
{
    public partial class DetalleArticulo : Form
    {
        public ListaArticulo lart;
        public string found;
        public string precio;
        public string categoria;
        public long codigo;
        public bool btn;
        public bool btn2;
        public DetalleArticulo(ListaArticulo lart,string found,string precio, string categoria)
        {
            InitializeComponent();
            this.lart = lart;
            this.found = found;  
            this.categoria = categoria;
            this.precio = precio;
            btn = false;
            btn2 = false;
        }
        private void DetalleArticulo_Load(object sender, EventArgs e)
        {
        
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Invalidate();
            Graphics p = panel1.CreateGraphics();
            lart.dibujar(p, lart, found, categoria, precio, panel1,btn,btn2,lz_DoubleClick);
        }

        private void DetalleArticulo_FormClosed(object sender, FormClosedEventArgs e)
        {       
        }
        private void lz_DoubleClick(object sender, EventArgs e)
        {
            
            Label lbl = sender as Label;
            if(lbl!=null)
            {
                
                VistadeArticulo va = new VistadeArticulo(lart,lbl.Text);
                va.ShowDialog();
            }
        }
        private void btnOrdenarasc_Click(object sender, EventArgs e)
        {
            Graphics p = panel1.CreateGraphics();
            btn2 = false;
            btn = true;
            lart.dibujar(p, lart, found, categoria, precio, panel1, btn,btn2,lz_DoubleClick);

        }

        private void btnOrdenardes_Click(object sender, EventArgs e)
        {
            Graphics p = panel1.CreateGraphics();
            btn = false;
            btn2 = true;
            lart.dibujar(p, lart, found, categoria, precio, panel1, btn,btn2,lz_DoubleClick);
        }
    }
}

//Action<Control.ControlCollection> func = null;
//func = (controls) =>
//             {
//                 foreach (Control control in controls)
//                     if (control is TextBox)
//                         (control as TextBox).Clear();
//                     else
//                         func(control.Controls);
//             };
//            func(Controls)

//imgs.ImageSize = new Size(100, 100);
//String[] paths = { };
//paths = Directory.GetFiles(@"C:\Users\Usuario\Downloads\Muñequito\Imagenes");
//            try
//            {
//                foreach(String path in paths)
//                {
//                    imgs.Images.Add(Image.FromFile(path));
//                }
//            }catch(Exception e)
//            {
//                MessageBox.Show(e.Message);
//            }
//            listView1.SmallImageList = imgs;
//            listView1.Items.Add("Primer articulo", 0);
//            listView1.Items.Add("Segundo articulo", 1);
//            listView1.Items.Add("Tercer articulo", 2);
//            listView1.Items.Add("Cuarto articulo", 3);
//            listView1.Items.Add("Quinto articulo", 4);
//            listView1.Items.Add("Sexto articulo", 5);
//            listView1.Items.Add("Septimo articulo", 6);
//            listView1.Items.Add("Octavo articulo", 7);
//            listView1.Items.Add("Noveno articulo", 8);
//            listView1.Items.Add("Decimo articulo", 9);
//            listView1.Items.Add("Undecimo articulo", 10);
//            listView1.Items.Add("Duodecimo articulo", 11);
//            listView1.Items.Add("Treceavo articulo", 12);
//            listView1.Items.Add("Catorceavo articulo", 13);
//            listView1.Items.Add("Quinceavo articulo", 14);
//            listView1.Items.Add("Dieciseisavo articulo", 15);
//            listView1.Items.Add("Diecisieteavo articulo", 16);