using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaComercio
{
    public abstract class Oveja
    {
        protected string sexo;
        protected int peso, edad;
        protected bool esApta;

        public Oveja()
        {
            sexo= string.Empty;
            peso= 0;
            edad= 0;
            esApta= false;
        }

        public string? GetSexo()
        {
            return sexo;
        }
        public void SetSexo(string? sexo)
        {
            this.sexo = sexo;
        }

        public int GetPeso()
        {
            return peso;
        }

        public void SetPeso(int peso)
        {
            this.peso = peso;
        }

        public int GetEdad()
        {
            return edad;
        }
        public void SetEdad(int edad)
        {
            this.edad = edad;
        }

        public bool GetEsApta()
        {
            return esApta;
        }

        public abstract double GetProduccion();
        public abstract void EvaluaSiEsApta();
    }
}
