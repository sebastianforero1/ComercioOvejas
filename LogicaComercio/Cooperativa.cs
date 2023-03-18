using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaComercio
{
    public class Cooperativa
    {
        //Zona de atributos

        private double valorComision;
        private double comisionObtenida;

        private double precioLana;
        private double precioLeche;
        private double ganancia;

        private int cantidadOvejas;

        private double cantidadKgLana;
        private double cantidadLtsLeche;
        private double ovejota;

        private Oveja[] lasOvejas;

        public Cooperativa(int cantidadOvejas)
        {
            this.cantidadOvejas = cantidadOvejas;
            valorComision= 0.05f;
            comisionObtenida= 0;
            precioLana= 1200;
            precioLeche= 1750;
            cantidadKgLana= 0;
            cantidadLtsLeche= 0;
            ganancia = 0;
            lasOvejas = new Oveja[cantidadOvejas];
            //Aqui se inicializa el arreglo de ovejas

            InicializaLasOvejas();
        }

        private void InicializaLasOvejas()
        {

            Random aleatorio = new Random();

            string[] losSexos = { "Macho", "Hembra" };
            string elSexo;
            int elPeso;
            int laEdad;
            double laCantidadLeche;

            for (int i = 0; i < lasOvejas.Length; i++)
            {
                elSexo = losSexos[aleatorio.Next(losSexos.Length)];
                elPeso = aleatorio.Next(1, 100);
                laEdad = aleatorio.Next(1, 144);
                //0: Oveja Lechera; 1: Oveja Lanuda
                switch (aleatorio.Next(2))
                {
                    case 0:
                        laCantidadLeche = aleatorio.NextDouble() * 3.5f;
                        lasOvejas[i] = new OvejaLechera(elSexo, elPeso, laEdad, laCantidadLeche);
                        break;
                    case 1:
                        lasOvejas[i] = new OvejaLanuda(elSexo, elPeso, laEdad);
                        break;

                }
            }
        }
        public void ContabilizaProduccion()
        {
            foreach(Oveja unaOveja in lasOvejas)
            {
                if (unaOveja.GetEsApta() && unaOveja.GetSexo() == "Macho")
                    cantidadKgLana += unaOveja.GetProduccion();
                if (unaOveja.GetEsApta() && unaOveja.GetSexo() == "Hembra")
                    cantidadLtsLeche += unaOveja.GetProduccion();
            }
        }

        public void CalculaComision()
        {
            ganancia = precioLana * cantidadKgLana + precioLeche* cantidadLtsLeche;
            comisionObtenida = ganancia * valorComision;

        }

        public override string ToString()
        {
            string informacion = $"Esta cooperativa cobra: {(valorComision * 100).ToString(".00")}% de comision,"+
                $"Se paga el KG de lana a ${precioLana} y el litro de leche a ${precioLeche}";
            return informacion;
        }
        int cantidadOvejasAptas = 0;

        private int CalculaCantidadOvejasAptas()
        {
            

            foreach (Oveja unaOveja in lasOvejas)
                if (unaOveja.GetEsApta())
                    cantidadOvejasAptas++;

            return cantidadOvejasAptas;
        }

        public string VisualizaResultadoComercio()
        {
            float porcentajeAptas = ((float)cantidadOvejasAptas / cantidadOvejas) * 100;
            string resultadoComercio = $"Del total de {cantidadOvejas}, solo {cantidadOvejasAptas} fueron aptas, equivalente al {porcentajeAptas.ToString(".00")}";
            

            resultadoComercio += $"\n La produccion consistio en {cantidadKgLana} Kgs de lana y {cantidadLtsLeche.ToString(".00")} litros de leche";

            resultadoComercio += $"El granjero obtuvo ganancias por ${(ganancia - comisionObtenida).ToString(".00")} y la cooperativa obtuvo {comisionObtenida.ToString(".00")}";
            return resultadoComercio;
        }



    }
}
