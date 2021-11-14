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
    public partial class ListarAgente : Form
    {
            menu MenuWindow = new menu();

            SqlConnection conn = new SqlConnection(conecctionSQL.conectionString);
            //List<classes.CDelincuente> listDelincuentes = new List<classes.CDelincuente>();

            public ListarAgente()
        {
            InitializeComponent();

        }

        private void ListarAgente_Load(object sender, EventArgs e)
        {

        }

        private void listBoxAgentes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
