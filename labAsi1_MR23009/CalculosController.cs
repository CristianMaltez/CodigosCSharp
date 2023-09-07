using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labAsi1_MR23009
{
    /// <summary>
    /// Clase encargada de hacer los calculos de costes de envio
    /// </summary>
    /// <author>Autor: Cristian Josué Maltez Rivas</author>
    class CalculosController
    {
        /// <summary>
        /// Variable usada para guardar el nombre del producto a calculo su total de envio con su respectivo getter y setter
        /// </summary>
        private string _nombreProducto;

        public string NombreProducto
        {
            get { return _nombreProducto; }
            set { _nombreProducto = value; }
        }

        /// <summary>
        /// Guarda el costo sin aplicar descuentos
        /// </summary>
        private double costoNeto = 0;

        public double CostoNeto
        {
            get { return costoNeto; }
            set { costoNeto = value; }
        }
        /// <summary>
        /// Variable usada para guardar el peso en kilos del producto con su respectivo getter y setter
        /// </summary>
        private double _pesoEnKilos;

        public double PesoEnKilos
        {
            get { return _pesoEnKilos; }
            set { _pesoEnKilos = value; }
        }

        /// <summary>
        /// Variable usada para guardar el precio del producto con su respectivo getter y setter
        /// </summary>
        private double _precio;

        public double Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        /// <summary>
        /// Variable usada para saber si el envio es dentro o fuera de san salvador con su respectivo getter y setter
        /// </summary>
        private bool _envioASanSalvador;

        public bool EnvioASanSalvador
        {
            get { return _envioASanSalvador; }
            set { _envioASanSalvador = value; }
        }

        public void calcularCostoNeto()
        {
            if (this._pesoEnKilos <= 1)
                this.costoNeto = 5;
            else if (this._pesoEnKilos > 1 && this._pesoEnKilos <= 5)
                this.costoNeto = 10;
            else
                this.costoNeto = 10 + (this._pesoEnKilos - 5) * 2;
        }

        public double calcularExtras()
        {
            if (this._envioASanSalvador)
               this.costoNeto -= (this.costoNeto * 0.1);
            else
               this.costoNeto += (this.costoNeto * 0.2);

            return this.costoNeto;
        }

        public double calcularTotal()
        {
            return (this.costoNeto + this._precio);
        }
    }
}
