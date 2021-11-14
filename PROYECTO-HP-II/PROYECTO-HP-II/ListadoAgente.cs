using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Collections.ObjectModel;

namespace PROYECTO_HP_II
{
    public partial class ListadoAgente : Form
    {
        menu MenuWindow = new menu();

        SqlConnection conn = new SqlConnection(conecctionSQL.conectionString);

        public string consulta { get; private set; }

        public ListadoAgente()
        {
            InitializeComponent();


            try
            {

                listBoxAgente();

            }
            catch (Exception ex)
            {
                MessageBox.Show(">>>>> Error EN  InitializeComponent \n" + ex.Message);
            }
           
        }
        private void listBoxAgente()
        {
            conn.Open();
            SqlCommand comandoConsult = new SqlCommand("SELECT Id FROM Agente", conn);
            SqlDataReader lector = comandoConsult.ExecuteReader();

            if (lector.HasRows)
            {
                while (lector.Read()) {
                    ListBoxAgente.Items.Add(lector.GetString(0));
                }
            }
            conn.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MenuWindow.Show();
            this.Close();
        }
        //ATRAS

        private void ListBoxAgente_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();

            string itemSelected = ListBoxAgente.SelectedItem.ToString();

            string consulta = "SELECT Nombre, Edad, Rango FROM Agente WHERE Id = @Id";

            SqlCommand comandoInsertLabels = new SqlCommand(consulta, conn);

            comandoInsertLabels.Parameters.AddWithValue("Id", itemSelected);
            SqlDataReader Lector = comandoInsertLabels.ExecuteReader();

            if (Lector.Read()) 
            {
                label12.Text = Lector.GetString(0);
                label11.Text = Convert.ToString(Lector.GetInt32(1));
                LabelEdad.Text = Lector.GetString(2);

                //MessageBox.Show("El numero del Agente es: " + LabelEdad.Text);
            }

            conn.Close();
           
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
