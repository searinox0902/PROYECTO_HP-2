﻿using System;
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
    public partial class menu : Form
    {

     

        public menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListaDelincuentes Ldelincuentes = new ListaDelincuentes();
            Ldelincuentes.Show();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            IngresarDelincuente ingresarDelincuente = new IngresarDelincuente();
            ingresarDelincuente.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditarDelincuente editarDelincuente = new EditarDelincuente();
            editarDelincuente.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListaCapturados listaCapturados = new ListaCapturados();
            listaCapturados.Show();
            this.Close();
        }


        private void button7_Click(object sender, EventArgs e)
        {
            EditarAgente EditAgente = new EditarAgente();
            EditAgente.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RegistrarAgente registrarAgenteWindow = new RegistrarAgente();
            registrarAgenteWindow.Show();
          }

   
        private void button5_Click_1(object sender, EventArgs e)
        {
            ListarAgente ListadoAgente = new ListarAgente();
            ListadoAgente.Show();

            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 inicioSesion = new Form1();
            inicioSesion.Show();
            this.Close();
        }
    }
}
