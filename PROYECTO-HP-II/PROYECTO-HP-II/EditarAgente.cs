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
    public partial class EditarAgente : Form
    {

        menu MenuWindow = new menu();
        SqlConnection conn = new SqlConnection(conecctionSQL.conectionString);

        List<classes.CAgente> ListaAgentes = new List<classes.CAgente>();

        public EditarAgente()
        {
            InitializeComponent();
            
            
           
            try
            {
                conn.Open();
                //ActualizarListbox();

                SqlCommand comandoInsertAgente= new SqlCommand("SELECT Id, Nombre, Edad, Rango, PIN FROM Agente", conn);

                SqlDataReader lectorAgente = comandoInsertAgente.ExecuteReader();


                
                if (lectorAgente.HasRows)
                {

                    while (lectorAgente.Read())
                    {
                        listBox1.Items.Add(lectorAgente.GetString(0));
                        ListaAgentes.Add(new classes.CAgente { Id = lectorAgente.GetString(0), Name = lectorAgente.GetString(1), Age = lectorAgente.GetInt32(2), Rango = lectorAgente.GetString(3), Pin = lectorAgente.GetInt32(4)}); 
                    };
                } 

                
                for (int i = 0; i > ListaAgentes.Count(); i++)
                {
                    MessageBox.Show(ListaAgentes[i].Id);
                } 

                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(">>>>> Error EN  InitializeComponent \n" + ex.Message);
            }

            conn.Close(); 
            
        }


        // ACTUALIZAR LISTBOX 


        public void ActualizarListbox()
        {

            listBox1.Items.Clear();

            conn.Open();

            SqlCommand comandoInsert = new SqlCommand("SELECT Id, Nombre, Edad, Rango, PIN  FROM Delincuente", conn);

            SqlDataReader lector = comandoInsert.ExecuteReader();

             /*
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    ListaAgentes.Add(new classes.CAgente { Id = lector.GetInt32(0), Name = lector.GetString(1), Age = lector.GetInt32(2), Rango = lector.GetString(3), Pin = lector.GetString(4)});
                };
            } 
             */

            conn.Close();
        }




        // SELECTED LISTBOX CHANGE
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idSeleccionado = listBox1.SelectedItem.ToString();

       

            for (int i = 0; i < ListaAgentes.Count(); i++)
            {
                if (idSeleccionado == ListaAgentes[i].Id)
                {
                    textBoxNombre.Text = ListaAgentes[i].Name;
                    textBoxEdad.Text = Convert.ToString(ListaAgentes[i].Age);
                    textBoxRango.Text = ListaAgentes[i].Rango;
                    textBoxPIN.Text = Convert.ToString(ListaAgentes[i].Pin);
                }
            }

        }

        //EDITAR
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                SqlCommand comandoUpdateAgente = new SqlCommand("UPDATE AGENTE SET Nombre = @nombre, Edad = @edad, Rango = @rango WHERE Id = @id;", conn);

                comandoUpdateAgente.Parameters.AddWithValue("nombre", textBoxNombre.Text);
                comandoUpdateAgente.Parameters.AddWithValue("edad", Convert.ToString(textBoxEdad.Text));
                comandoUpdateAgente.Parameters.AddWithValue("rango", textBoxRango.Text);
                comandoUpdateAgente.Parameters.AddWithValue("id", listBox1.SelectedItem.ToString());

                comandoUpdateAgente.ExecuteNonQuery();

                MessageBox.Show("Se han ingresado los datos");
            }catch(Exception ex)
            {
                MessageBox.Show("Error:  Digite correctamente los datos");
            }

            conn.Close();
        }


        // ATRÁS

        private void button2_Click(object sender, EventArgs e)
        {
            MenuWindow.Show();
            this.Close();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBoxEdad_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPIN_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelPIN_Click(object sender, EventArgs e)
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

        private void textBoxRango_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia");
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

        private void textBoxPIN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros","Advertencia");
                e.Handled = true;
                return;
            }
        }

        private void textBoxRango_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
