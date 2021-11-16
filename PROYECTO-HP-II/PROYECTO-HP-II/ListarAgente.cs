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
    public partial class ListarAgente : Form
    {


        menu MenuWindow = new menu();

        SqlConnection conn = new SqlConnection(conecctionSQL.conectionString);

        public ListarAgente()
        {
            InitializeComponent();


            try
            {

               ListBoxAgente();

            }
            catch (Exception ex)
            {
                MessageBox.Show(">>>>> Error EN  InitializeComponent \n" + ex.Message);
            }
        }

        private void ListBoxAgente()
        {
            conn.Open();
            SqlCommand comandoConsult = new SqlCommand("SELECT Id FROM Agente", conn);
            SqlDataReader lector = comandoConsult.ExecuteReader();

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    listBoxAgente.Items.Add(lector.GetString(0));
                }
            }
            conn.Close();
        }



        private void ListarAgente_Load(object sender, EventArgs e)
        {

        }

        private void listBoxAgente_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();

            string itemSelected = listBoxAgente.SelectedItem.ToString();

            string consulta = "SELECT Nombre, Edad, Rango FROM Agente WHERE Id = @Id";

            SqlCommand comandoInsertLabels = new SqlCommand(consulta, conn);

            comandoInsertLabels.Parameters.AddWithValue("Id", itemSelected);
            SqlDataReader Lector = comandoInsertLabels.ExecuteReader();

            if (Lector.Read())
            {
                labelNombre.Text = Lector.GetString(0);
                labelEdad.Text = Convert.ToString(Lector.GetInt32(1));
                labelRango.Text = Lector.GetString(2);

                //MessageBox.Show("El numero del Agente es: " + LabelEdad.Text);
            }

            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuWindow.Show();
            this.Close();
        }
    }
}
