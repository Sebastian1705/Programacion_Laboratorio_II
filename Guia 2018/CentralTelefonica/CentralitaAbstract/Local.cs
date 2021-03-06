﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaAbstract
{
    /*Local:
    d. Sobreescribir el método Mostrar. Será protegido. Reutilizará el código escrito en la clase
    base y además agregará la propiedad CostoLlamada, utilizando un StringBuilder.
    e. Equals retornará true sólo si el objeto que recibe es de tipo Local.
    f. ToString reutilizará el código del método Mostrar*/
    public class Local : Llamada
    {
        #region Fields

        private float costo;

        #endregion

        #region Propieties

        /// <summary>
        /// La propiedad CostoLlamada retornará el precio, que se calculará en el método CalcularCosto
        /// </summary>
        public float CostoLlamada
        {
            get
            {
                return this.CalcularCosto();
            }
        }

        #endregion

        #region Methods

        public Local(Llamada l1, float costo)
            : this(l1.NroOrigen, l1.Duracion, l1. NroDestino, costo)
        {

        }

        public Local(string origen, float duracion, string destino, float costo)
            : base(duracion, destino, origen)
        {
            this.costo = costo;
        }

        /// <summary>
        /// CalcularCosto será privado. Retornará el valor de la llamada a partir de la duración y el costo de la misma.
        /// </summary>
        /// <returns></returns>
        private float CalcularCosto()
        {
            return this.Duracion * this.costo;
        }

        /// <summary>
        /// Método Mostrar expondrá, además de los atributos de la clase base, la propiedad CostoLlamada.Utilizar StringBuilder.
        /// </summary>
        /// <returns></returns>
        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{base.Mostrar()} - Costo: {this.CostoLlamada}");
            return sb.ToString();
        }

        public override string ToString()
        {
            return this.Mostrar();
        }

        public override bool Equals(object obj)
        {
            if (obj is Local)
                return true;
            return false;
        }

        #endregion
    }
}
