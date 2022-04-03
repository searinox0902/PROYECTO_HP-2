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
    public partial class RegistrarAgente : Form
    {
        SqlConnection conn = new SqlConnection(conecctionSQL.conectionString);
    
        public RegistrarAgente()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            menu menuWindow = new menu();
            menuWindow.Show();
            this.Close();
        }

        private void buttonRegistrar_Click(object sender, EventArgs e)
        {
            conn.Open();


            string insertData = "INSERT INTO Agente(Id, Nombre, Rango, Edad,  PIN) VALUES(@id, @nombre, @rango, @edad, @pin)";

            SqlCommand comandoInsert = new SqlCommand(insertData, conn);

            comandoInsert.Parameters.AddWithValue("id", textBoxNombre.Text);
            comandoInsert.Parameters.AddWithValue("pin", textBoxPIN.Text);
            comandoInsert.Parameters.AddWithValue("nombre", textBoxNombre.Text);
            comandoInsert.Parameters.AddWithValue("rango", textBoxRango.Text);
            comandoInsert.Parameters.AddWithValue("edad", Convert.ToInt32(textBoxEdad.Text));

            try
            {
                comandoInsert.ExecuteNonQuery();
                MessageBox.Show("Agente Registrado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Agente ya se encuentra registrado o Datos ingresados incorrectamente " + ex);
            }


            conn.Close();
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

        private void textBoxId_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxPIN_KeyPress(object sender, KeyPressEventArgs e)
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
