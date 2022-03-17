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

namespace PROYECTO_HP_II
{
    public partial class Form1 : Form
    {
     
        //string paramConn = "";
        SqlConnection conn = new SqlConnection(conecctionSQL.conectionString);
        
        //ventana Menu
        menu MenuWindow = new menu();

        public Form1()
        {
            InitializeComponent();
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error DatabaseConection \n" + ex.Message);
            }

            conn.Close();
        }


        // INGRESAR

        private void button1_Click(object sender, EventArgs e)
        {   


                
           

            string consulta = "SELECT Id, PIN FROM Agente WHERE Id = @id AND Pin = @pin";

            try
            {
                conn.Open();
                SqlCommand comando = new SqlCommand(consulta, conn);
                comando.Parameters.AddWithValue("id", textBox1.Text);
                comando.Parameters.AddWithValue("pin", textBox2.Text);
                SqlDataReader lector = comando.ExecuteReader();

                if (lector.Read())
                {
                    MenuWindow.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, asegurese que los datos ingresados sean correctos \n" + ex.Message);
            }

          

            conn.Close();
        }

        // REGISTRAR

        private void button2_Click(object sender, EventArgs e)

        {
            conn.Open();

                string insertData = "INSERT INTO Agente(Id, PIN) VALUES(@id, @pin)";

                try
                {
                    SqlCommand comandoInsert = new SqlCommand(insertData, conn);

                    comandoInsert.Parameters.AddWithValue("id", textBox1.Text);
                    comandoInsert.Parameters.AddWithValue("pin", textBox2.Text);
                    comandoInsert.ExecuteNonQuery();

                    MessageBox.Show("Agente Registrado");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Agente ya se encuentra registrado o Datos ingresados Incorrectamente (SOLO NUMEROS EN PIN)");
                } 
        
          
            conn.Close();

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
    }
}
