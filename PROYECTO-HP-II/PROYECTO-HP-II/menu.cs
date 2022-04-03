using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTO_HP_II
{
    public partial class menu : Form
    {



        public menu()
        {
            InitializeComponent();
            customizeDesing();
        }

        private void customizeDesing()
        {
            panelMeDelincuentes.Visible = false;
            panelMAgentes.Visible = false;
        }

        private void hideMenu()
        {
            if (panelMeDelincuentes.Visible == true)
            {
                panelMeDelincuentes.Visible = false;
            }

            if (panelMAgentes.Visible == true)
            {
                panelMAgentes.Visible = false;
            }
        }

        private void showMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new ListaDelincuentes());
            /*ListaDelincuentes Ldelincuentes = new ListaDelincuentes();
            Ldelincuentes.Show();
            this.Close();*/
            hideMenu();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new IngresarDelincuente());
            /*IngresarDelincuente ingresarDelincuente = new IngresarDelincuente();
            ingresarDelincuente.Show();
            this.Hide();*/
            hideMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new EditarAgente());
            /*EditarDelincuente editarDelincuente = new EditarDelincuente();
            editarDelincuente.Show();
            this.Close();*/
            hideMenu();
        }

        private void AbrirFormInPanel(object Formhijo) 
        {
            if (this.panelchildrensub.Controls.Count > 0) 
            {
                this.panelchildrensub.Controls.RemoveAt(0);
                Form fh = Formhijo as Form;
                fh.TopLevel = false;
                fh.Dock = DockStyle.Fill;
                fh.FormBorderStyle = FormBorderStyle.None;
                this.panelchildrensub.Controls.Add(fh);
                this.panelchildrensub.Tag = fh;
                fh.Show();
            }
                
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new ListaCapturados());

            /*ListaCapturados listaCapturados = new ListaCapturados();
            listaCapturados.Show();
            this.Close();*/
            hideMenu();
        }


        private void button7_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new EditarAgente());
            /*EditarAgente EditAgente = new EditarAgente();
            EditAgente.Show();
            this.Close();*/
            hideMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new RegistrarAgente());
            /*RegistrarAgente registrarAgenteWindow = new RegistrarAgente();
            registrarAgenteWindow.Show();*/
            hideMenu();
        }


        private void button5_Click_1(object sender, EventArgs e)
        {
            AbrirFormInPanel(new ListarAgente());
            /*ListarAgente ListadoAgente = new ListarAgente();
            ListadoAgente.Show();
            this.Close();*/
            hideMenu();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            /*Form1 inicioSesion = new Form1();
            inicioSesion.Show();
            this.Close();*/
        }

        private void pMenuLatl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menu_Load(object sender, EventArgs e)
        {

        }

        private void btnDelincuentes_Click(object sender, EventArgs e)
        {
            showMenu(panelMeDelincuentes);
        }

        private void btnAgentes_Click(object sender, EventArgs e)
        {
            showMenu(panelMAgentes);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Form1 inicioSesion = new Form1();
            inicioSesion.Show();
            this.Close();
        }

        //Colocar form sobre form, otro metodo de hacerlo.
        /*private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                panelchildrensub.Controls.Add(childForm);
                panelchildrensub.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }
        }     */ 

        private void panelchildrensub_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
