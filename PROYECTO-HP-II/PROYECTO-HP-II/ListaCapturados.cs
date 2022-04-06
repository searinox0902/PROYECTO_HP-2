using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTO_HP_II
{
    public partial class ListaCapturados : Form
    {
        menu MenuWindow = new menu();
        SqlConnection conn = new SqlConnection(conecctionSQL.conectionString);

        public ListaCapturados()
        {   

            InitializeComponent();
            listBox1.Items.Clear();
            ActualizarListBox();
        }

        // FUNCION ACTUALIZA LISTBOX
        private void ActualizarListBox()
        {
           

            conn.Open();
            try
            {
                SqlCommand comandoInsert = new SqlCommand("SELECT Id, Nombre, FechaCaptura, Delito FROM Capturados", conn);

                SqlDataReader lector = comandoInsert.ExecuteReader();


                if (lector.HasRows)
                {
                   
                    while (lector.Read())
                    {
                        listBox1.Items.Add(lector.GetString(0));
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(">>>>> Error EN  InitializeComponent \n" + ex.Message);
            }

            conn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0); //sobra si tienes la posición en el diseño
            this.Size = new Size(this.Width, Screen.PrimaryScreen.WorkingArea.Size.Height);
        }

        // FUNCION ACTUALIZA LABELS 
        private void ActualizarLabels()
        {
            string itemSelected = listBox1.SelectedItem.ToString();

            conn.Open();

            SqlCommand comandoInsertLabels = new SqlCommand("SELECT Nombre, Alias, FechaCaptura, Delito FROM Capturados WHERE Id = @id", conn);

            comandoInsertLabels.Parameters.AddWithValue("id", itemSelected);
            SqlDataReader lectorCapturados = comandoInsertLabels.ExecuteReader();

            if (lectorCapturados.Read())
            {

              
                labelNombre.Text = lectorCapturados.GetString(0);
                labelAlias.Text  = lectorCapturados.GetString(1);
                labelFecha.Text  = Convert.ToString(lectorCapturados.GetDateTime(2));
                labelCode.Text = lectorCapturados.GetString(3); 
            }

            conn.Close();

            // Actualizar Delitos
            conn.Open();

            SqlCommand commandDelito = new SqlCommand("SELECT Descripcion FROM Delito WHERE Id = @idDelito", conn);

            commandDelito.Parameters.AddWithValue("idDelito", labelCode.Text);

            SqlDataReader readerDelito = commandDelito.ExecuteReader(0);


            if (readerDelito.Read())
            {
                labelDesc.Text = readerDelito.GetString(0);
            }



            conn.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           
            ActualizarLabels();
        }



        // ATRAS
        private void button2_Click(object sender, EventArgs e)
        {
            MenuWindow.Show();
            this.Hide();
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

      
    }
}
