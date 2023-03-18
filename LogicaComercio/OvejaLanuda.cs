using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaComercio
{
    public class OvejaLanuda: Oveja
    {
        private double cantidadLana;

        public OvejaLanuda() : base()
        {
            cantidadLana= 0;
        }

        public OvejaLanuda(string sexo, int peso, int edad)
        {
            this.peso = peso;
            this.edad= edad;
            this.sexo= sexo;

            EvaluaSiEsApta();
        }

        public double GetCantidadLana()
        {
            return cantidadLana;
        }

        public override void EvaluaSiEsApta()
        {
            if (peso >= 35)
                cantidadLana = peso * 0.2f;
            else
                cantidadLana = 0;

            if (edad >= 24 && edad <= 84 && peso >= 35 && sexo == "Macho")
                esApta = true;
        }

        public override double GetProduccion()
        {
            return cantidadLana;
        }

        public override string ToString()
        {
            string resultado = $"Oveja {sexo}, peso: {peso}, edad: {edad}, " +
                $"cantidad de lana: {cantidadLana.ToString("00.00")}. ";
            if (esApta)
                resultado += "Es apta";
            else
                resultado += "No es apta";

            return resultado;
        }
    }
}
