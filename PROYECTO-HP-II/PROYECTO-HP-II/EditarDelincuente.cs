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
    public partial class EditarDelincuente : Form
    {
        menu MenuWindow = new menu();
        SqlConnection conn = new SqlConnection(conecctionSQL.conectionString);
        
        List<classes.CDelito> DelitoList = new List<classes.CDelito>();
        List<classes.CDelincuente> DelincuentesList = new List<classes.CDelincuente>();

        public EditarDelincuente()
        {
            InitializeComponent();

            try
            {

                ActualizarListbox();

                conn.Open();
                    SqlCommand comandoInsertDelito = new SqlCommand("SELECT Id, Descripcion FROM Delito", conn);

                    SqlDataReader lectorDelito = comandoInsertDelito.ExecuteReader();

                    

                    if (lectorDelito.HasRows)
                    {
                   
                        while (lectorDelito.Read())
                        {
                            domainUpDown1.Items.Add(lectorDelito.GetString(0));
                       
                            DelitoList.Add(new classes.CDelito { Id = lectorDelito.GetString(0), Descripcion = lectorDelito.GetString(1) });
                        }; 
                    }
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(">>>>> Error EN  InitializeComponent \n" + ex.Message);
            }

            conn.Close  ();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        //Atrás
        private void button2_Click(object sender, EventArgs e)
        {
            MenuWindow.Show();
            this.Hide();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();

            string itemSelected = listBox1.SelectedItem.ToString();


            string consulta = "SELECT Id, Nombre, Alias, Edad, Ubicacion, Foto, Id_Delito FROM Delincuente WHERE Id = @id";


            SqlCommand comando = new SqlCommand(consulta, conn);

            comando.Parameters.AddWithValue("id", itemSelected);

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {

                classes.CDelincuente Delincuente = new classes.CDelincuente();


                Delincuente.Id = reader.GetString(0);
                Delincuente.Nombre = reader.GetString(1);
                Delincuente.Alias = reader.GetString(2);
                Delincuente.Edad = reader.GetInt32(3);
                Delincuente.Ubicacion = reader.GetString(4);
                //  Delincuente.url = null;
                Delincuente.Delito = reader.GetString(6);


                //Nombre
                textBoxNombre.Text = Delincuente.Nombre;

                //Alias
                textBoxAlias.Text = Delincuente.Alias;

                //Id
                textBoxID.Text = Delincuente.Id;

                //Delito
                labelDelito.Text = "Delito : " + Delincuente.Delito;

                // Ultima Ubicacion
                textBoxUbicacion.Text = Delincuente.Ubicacion;

                // Edad
                textBoxEdad.Text = Convert.ToString(Delincuente.Edad);


            }
            else {
                MessageBox.Show("No se puede leer los datos");
            };

            conn.Close();
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

            string codigo = domainUpDown1.Text;

            for (int i = 0; i < DelitoList.Count; i++)
            {
                if (codigo == DelitoList[i].Id)
                {
                    texboxDesc.Text = DelitoList[i].Descripcion;
                }
            }
        }

        //EditarDelincuente

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                conn.Open();
                SqlCommand comandoUpdate = new SqlCommand("UPDATE Delincuente SET Id = @id, Nombre = @name, Alias = @alias, Edad = @edad, Ubicacion = @ubicacion, Foto = null, Id_Delito = @delito WHERE Id = @IdRefrencia", conn);

                comandoUpdate.Parameters.AddWithValue("id", textBoxID.Text);
                comandoUpdate.Parameters.AddWithValue("name", textBoxNombre.Text);
                comandoUpdate.Parameters.AddWithValue("alias", textBoxAlias.Text);
                comandoUpdate.Parameters.AddWithValue("edad", textBoxEdad.Text);
                comandoUpdate.Parameters.AddWithValue("ubicacion", textBoxUbicacion.Text);
                comandoUpdate.Parameters.AddWithValue("delito", domainUpDown1.Text);

                comandoUpdate.Parameters.AddWithValue("IdRefrencia", listBox1.SelectedItem.ToString());

                int flag = comandoUpdate.ExecuteNonQuery();


                if (flag == 1)
                {
                    MessageBox.Show("Datos Ingresados Correctamente");
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(">>>>> Error UpdateDelincuente \n" + ex.Message);
            }
      


            conn.Close();

            ActualizarListbox();
        }
    
        //Metodo 

        public void ActualizarListbox()
        {

            listBox1.Items.Clear();

            conn.Open();

            SqlCommand comandoInsert = new SqlCommand("SELECT Id, Nombre, Alias, Edad, Ubicacion, Foto, Id_Delito FROM Delincuente", conn);

            SqlDataReader lector = comandoInsert.ExecuteReader();


            if (lector.HasRows)
            {

                while (lector.Read())
                {
                    listBox1.Items.Add(lector.GetString(0));

                    DelincuentesList.Add(new classes.CDelincuente { Id = lector.GetString(0), Nombre = lector.GetString(1), Alias = lector.GetString(2), Edad = lector.GetInt32(3), Ubicacion = lector.GetString(4), Delito = lector.GetString(6), });
                };
            }

            conn.Close();
        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAlias_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia");
                e.Handled = true;
                return;
            }
        }

        private void textBoxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia");
                e.Handled = true;
                return;
            }
        }

        private void textBoxEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia");
                e.Handled = true;
                return;
            }
        }
    }
}
