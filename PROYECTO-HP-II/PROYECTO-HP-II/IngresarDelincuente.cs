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
    public partial class IngresarDelincuente : Form
    {
        SqlConnection conn = new SqlConnection(conecctionSQL.conectionString);


        List<classes.CDelito> DelitoList = new List<classes.CDelito>();

        public IngresarDelincuente()
        {
            InitializeComponent();

            try
            {
                conn.Open();

                SqlCommand comandoInsert = new SqlCommand("SELECT Id, Descripcion FROM Delito", conn);

                SqlDataReader lector = comandoInsert.ExecuteReader();



                if (lector.HasRows)
                {

                    while (lector.Read())
                    {
                        domainUpDown1.Items.Add(lector.GetString(0));

                        DelitoList.Add(new classes.CDelito { Id = lector.GetString(0), Descripcion = lector.GetString(1) });
                    };
                }

                // MessageBox.Show(Convert.ToString(DelitoList[0].Id));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error DatabaseConection \n" + ex.Message);
                this.Hide();
            }


            conn.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {


            string codigo = domainUpDown1.Text; 
            
            for(int i = 0; i < DelitoList.Count; i++)
            {
                if (codigo == DelitoList[i].Id)
                {
                    texboxDesc.Text = DelitoList[i].Descripcion;
                }
            }

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        // ATRÁS
        
        private void button2_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            menu.Show();
            this.Hide();
        }
           

        // INGRESAR DELINCUENTE

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();


            string insertData = "INSERT INTO Delincuente(Id, Nombre, Alias, Edad, Ubicacion, Id_Delito) VALUES(@id, @nombre, @alias, @edad, @ubicacion, @delito)";

            SqlCommand comandoInsert = new SqlCommand(insertData, conn);

           
            comandoInsert.Parameters.AddWithValue("nombre", textBox1.Text);
            comandoInsert.Parameters.AddWithValue("alias", textBox2.Text);
            comandoInsert.Parameters.AddWithValue("id", textBox3.Text);
            comandoInsert.Parameters.AddWithValue("edad", textBox4.Text);
          //  comandoInsert.Parameters.AddWithValue("foto", null);
            comandoInsert.Parameters.AddWithValue("delito", domainUpDown1.Text);
            comandoInsert.Parameters.AddWithValue("ubicacion", textBox6.Text);

            try
            {
                comandoInsert.ExecuteNonQuery();
                MessageBox.Show("Delincuente Registrado");

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                texboxDesc.Text = "";
                domainUpDown1.ResetText();
                textBox6.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Agente ya se encuentra registrado o Datos ingresados incorrectamente " + ex);
            }


            conn.Close();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void texboxDesc_TextChanged(object sender, EventArgs e)
        {
           


           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
