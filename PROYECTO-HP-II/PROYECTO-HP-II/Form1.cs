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
    public partial class Form1 : Form
    {
        //ventana Menu

        menu MenuWindow = new menu();

        List<classes.CAgente> ListUsers = new List<classes.CAgente>();
        int index = 0;


        int id = 0;
        string pass = null;


        public Form1()
        {
            InitializeComponent();

            // Objeto Agente de Prueba
            ListUsers.Add(new classes.CAgente() { Name = "Juan", Pass = "123", Age = 0, Id = 000, Captures = 0, UrlPicture = null });
            ListUsers.Add(new classes.CAgente() { Name = "Juan", Pass = "123", Age = 0, Id = 001, Captures = 0, UrlPicture = null });
            ListUsers.Add(new classes.CAgente() { Name = "Juan", Pass = "123", Age = 0, Id = 002, Captures = 0, UrlPicture = null });
            ListUsers.Add(new classes.CAgente() { Name = "Juan", Pass = "123", Age = 0, Id = 003, Captures = 0, UrlPicture = null });

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

      
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        // INGRESAR

        private void button1_Click(object sender, EventArgs e)
        {
  
            
            if(ListUsers.Count > 0)
            {   
               
                try {
                    id = Convert.ToInt32(textBox1.Text);
                    pass = textBox2.Text;
                    
                    int count = 0;

                    // recorremos el objeto agente en la lista con un foreach, 
                    // comparamos y si encuentra coincidencia cierra la ventana
                    
                    foreach (classes.CAgente item in ListUsers)
                    {
                        if(item.Id == id && item.Pass == pass)
                        {
                            MessageBox.Show("Bienvenido Agente" + Convert.ToString(count));
                            textBox1.Clear();
                            textBox2.Clear();

                            MenuWindow.Show();
                            this.Hide();
                           

                        }
                        count++;
                    }

                    // si el foreach recorrio toda la lista, se compara la variable count 
                    // con la longitud de la lista ListUser

                    if (count == ListUsers.Count)
                    {
                        MessageBox.Show("El agente no existe!");
                        textBox1.Clear();
                        textBox2.Clear();
                    }

                } catch (System.FormatException) {
                    MessageBox.Show("Por favor ingrese los datos correctamente");
                    textBox1.Clear();
                    textBox2.Clear();
                }
            } else
            {

                textBox1.Clear();
                textBox2.Clear();
                MessageBox.Show(Convert.ToString("No hay Agentes registrados, ingrese como administrador o comuniquese con el soporte."));
            } 
        }

        // REGISTRAR

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                id = Convert.ToInt32(textBox1.Text);
                pass = textBox2.Text;

                ListUsers.Add(new classes.CAgente() { Name = null, Pass = pass, Age = 0, Id = id, Captures = 0, UrlPicture = null });

            }
            catch (System.FormatException)
            {
                MessageBox.Show("Por favor ingrese los datos correctamente");
            }
        }

    }
}
