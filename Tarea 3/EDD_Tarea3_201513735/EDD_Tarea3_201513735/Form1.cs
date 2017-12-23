using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EDD_Tarea3_201513735
{
    public partial class Form1 : Form
    {
        Arbol arbol;
        public Form1()
        {
            InitializeComponent();
            arbol = new Arbol();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.consola.Text = "Preorden: " + arbol.PreOrden() + "PostOrden: " + arbol.PostOrden() + "InOrden: " + arbol.InOrden() ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.arbol.Insertar(int.Parse(this.dato.Text));
                MessageBox.Show("Insertado con exito.");
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
            
        }
    }
}
