using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labAsi1_MR23009
{
    public partial class Form1 : Form
    {
        CalculosController calculos = new CalculosController();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool converted = false;
            double conversiones = 0;
            string mensajeRespuesta = "";
            double total = 0;

            if ( String.IsNullOrEmpty(txtNombreProducto.Text) )
            {
                MessageBox.Show("Es requerido el nombre del producto");
                return;
            }

            converted = double.TryParse(txtPeso.Text, out conversiones);

            if ( !converted || (conversiones <= 0 ) )
            {
                MessageBox.Show("Es requerido un valor númerico positivo en el peso del producto");
                return;
            }

            calculos.PesoEnKilos = conversiones;


            converted = double.TryParse(txtPrecio.Text, out conversiones);

            if (!converted || (conversiones <= 0) )
            {
                MessageBox.Show("Es requerido un valor númerico positivo en el precio del producto");
                return;
            }

            calculos.Precio = conversiones;

            calculos.NombreProducto = txtNombreProducto.Text;

            if (rbtSanSalvador.Checked)
            {
                calculos.EnvioASanSalvador = true;
                txtDescuento.Text = "Se le aplicara un descuento del 10%";
            }
            else
            {
                txtDescuento.Text = "Se le aplicara un cargo extra del 20%";

            }


            calculos.calcularCostoNeto();
            calculos.calcularExtras();
            total = calculos.calcularTotal();

            mensajeRespuesta = "Nombre del producto: " + calculos.NombreProducto + "Precio producto: $" + calculos.Precio.ToString("F2") + "Coste de Envio: $" + calculos.CostoNeto.ToString("F2") + "Total a pagar: $" + total.ToString("F2");

            txtResultado.Text = mensajeRespuesta;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPrecio.Text = null;
            txtPeso.Text = null;
            txtNombreProducto.Text = null;
            txtResultado.Text = null;
            txtDescuento.Visible = false;
        }

        private void rbtSanSalvador_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
