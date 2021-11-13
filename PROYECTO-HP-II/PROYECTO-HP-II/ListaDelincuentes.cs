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
    public partial class ListaDelincuentes : Form
    {

        menu MenuWindow = new menu();

        SqlConnection conn = new SqlConnection(conecctionSQL.conectionString);
        //List<classes.CDelincuente> listDelincuentes = new List<classes.CDelincuente>();


        public ListaDelincuentes()
        {
            InitializeComponent();

   

            try
            {
     
                 ActualizarListBox();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(">>>>> Error EN  InitializeComponent \n" + ex.Message);
            }
        }

       
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();

            string itemSelected = listBox1.SelectedItem.ToString();

        

            string consulta = "SELECT Id, Nombre, Alias, Edad, Ubicacion, Foto, Id_Delito FROM Delincuente WHERE Nombre = @nombre";

           
            SqlCommand comando = new SqlCommand(consulta, conn);

            comando.Parameters.AddWithValue("nombre", itemSelected);

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                int index = reader.VisibleFieldCount;

                classes.CDelincuente Delincuente = new classes.CDelincuente();

            
                    Delincuente.Id = reader.GetString(0);
                    Delincuente.Nombre = reader.GetString(1);
                    Delincuente.Alias = reader.GetString(2);
                    Delincuente.Edad = reader.GetInt32(3);
                    Delincuente.Ubicacion = reader.GetString(4);
                  //  Delincuente.url = null;
                    Delincuente.Delito = reader.GetString(6);


                //Nombre
                label12.Text = Delincuente.Nombre;

                //Alias
                label13.Text = Delincuente.Alias;

                //Id
                label14.Text = Delincuente.Id;


                // Ultima Ubicacion
                label15.Text = Delincuente.Ubicacion;

                // Delito
                label16.Text = Delincuente.Delito;

                conn.Close();


                conn.Open();

                SqlCommand commandDelito = new SqlCommand("SELECT Descripcion FROM Delito WHERE Id = @idDelito", conn);

                commandDelito.Parameters.AddWithValue("idDelito", label16.Text);

                SqlDataReader readerDelito = commandDelito.ExecuteReader(0);


                if (readerDelito.Read())
                {
                    label17.Text = readerDelito.GetString(0);
                }



                conn.Close();
            }; 

       
        }


        private void registrarCaptura_Click(object sender, EventArgs e)
        {

            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("No hay delincuentes para Capturar");
            }
            else
            {

                bool flag = false;
                DateTime today = DateTime.Today;

                string idCapturado = "KGB" + label14.Text;

                try
                {

                    conn.Open();

                    string insertData = "INSERT INTO Capturados(Id, Delito, Alias, FechaCaptura, Nombre) VALUES(@idCapturado, @delito, @alias, @fechaCaptura, @nombre)";
                    SqlCommand comandoInsert = new SqlCommand(insertData, conn);



                    comandoInsert.Parameters.AddWithValue("idCapturado", idCapturado);
                    comandoInsert.Parameters.AddWithValue("alias", label13.Text);
                    comandoInsert.Parameters.AddWithValue("delito", label16.Text); 
                    comandoInsert.Parameters.AddWithValue("fechaCaptura", today);
                    comandoInsert.Parameters.AddWithValue("nombre", label12.Text);


                    comandoInsert.ExecuteNonQuery();

                    MessageBox.Show("Se ha registrado la Captura de : " + label12.Text);
                    flag = true;


                }
                catch (Exception ex)
                {
                    MessageBox.Show(">>>>> Error EN  RegistrarCaptura() \n" + ex.Message);
                }

                conn.Close();

                // Si ingresa el Capturado Correctamente Haga:
                if (flag == true)
                {
                    conn.Open();


                    try
                    {
                        string deletetData = "DELETE FROM Delincuente WHERE Id = @idDelincuente";
                        SqlCommand comandoDelete = new SqlCommand(deletetData, conn);



                        comandoDelete.Parameters.AddWithValue("idDelincuente", label14.Text);

                        comandoDelete.ExecuteNonQuery();

                        MessageBox.Show(Convert.ToString(comandoDelete.ExecuteNonQuery()));

                        MessageBox.Show("Se ha eliminado del registro: " + label12.Text);
                        conn.Close();

                        ActualizarListBox();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar Registro " + ex);
                    }

                }
            }

        }


        // ATRAS
        private void button2_Click(object sender, EventArgs e)
        {
            MenuWindow.Show();
            this.Close();
        }


        private void ActualizarListBox() {
            conn.Open();
            listBox1.Items.Clear();
            SqlCommand comandoInsert = new SqlCommand("SELECT Nombre FROM Delincuente", conn);

            SqlDataReader lector = comandoInsert.ExecuteReader();

            if (lector.HasRows)
            {
                while (lector.Read())
                    {
                        listBox1.Items.Add(lector.GetString(0));
                    };
            };
            conn.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

    }
}
