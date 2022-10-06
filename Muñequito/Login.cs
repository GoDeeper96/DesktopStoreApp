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
    public partial class Login : Form
    {
        public ListaClientes l_c;
        public Login()
        {
            InitializeComponent();
            l_c = new ListaClientes();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            RegistroUsuario reg = new RegistroUsuario(l_c);
            reg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            //VALIDACIONES TEXTBOX
            if (l_c.ValidacionUsuario(txtContraseña.Text, txtUsuario.Text))
            {
                Buscador b = new Buscador(txtUsuario.Text);
                MessageBox.Show("Login exitoso!!");
                b.Show();
            }
            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
