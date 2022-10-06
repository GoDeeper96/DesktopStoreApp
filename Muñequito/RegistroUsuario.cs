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
    public partial class RegistroUsuario : Form
    {
        public ListaClientes l_c;
        public RegistroUsuario(ListaClientes l_c)
        {
            InitializeComponent();
            this.l_c = l_c;

        }
        private void ClearTextBoxes()
        {
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
        }

        private void RegistrarUsuario()
        {
            
            Cliente nuevo = new Cliente();
            nuevo.nombre = txtNombre.Text;
            nuevo.alias = txtRegistroAlias.Text;
            nuevo.correo = txtRegistroCorreo.Text;
            nuevo.id = txtRegistroUsuario.Text;
            nuevo.contraseña = txtRegistroContraseña.Text;
            nuevo.estadio = ESTADO.antiguo;
            l_c.InsertarDatos(nuevo);
            nuevo.estadio = ESTADO.nuevo;
            l_c.Update(l_c.lista_de_clientes);
            nuevo.estadio = ESTADO.antiguo;
            
            ClearTextBoxes();
        }
        private void RegistroUsuario_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {

            RegistrarUsuario();     
            MessageBox.Show("Usuario registrado con exito!");
            this.Close();

        }
    }
}
