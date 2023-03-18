using System;
using LogicaComercio;

namespace ComercioOvejas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Programa para simular el comercio de ovejas");

            int cantidadOvejas = 0;
            bool datoCorrecto = false;
            do
            {
                try
                {
                    Console.WriteLine("Ingresa la cantidad de ovejas a procesar en la Cooperativa: ");
                    cantidadOvejas = int.Parse(Console.ReadLine());
                    if (cantidadOvejas > 0)
                        datoCorrecto = true;
                    else
                        Console.WriteLine("La cantidad de ovejas debe ser un entero positivo. Intentalo nuevamente ");

                }
                catch (FormatException)
                {
                    Console.WriteLine("El dato ingresado no tiene el formato requerido. Intentalo nuevamente");
                }

            }
            while (!datoCorrecto);

            Console.WriteLine("");

            Cooperativa coop = new Cooperativa(cantidadOvejas);

            //Calculo de produccion

            coop.ContabilizaProduccion();
            coop.CalculaComision();

            Console.WriteLine(coop.ToString());
            Console.WriteLine(coop.VisualizaResultadoComercio());






            //Aqui se visualizan las ovejas aptas:
            /*
            int contadorOvejasAptas = 0;
            int totalOvejas = 1;

            foreach(Oveja unaOveja in lasOvejas)
            {
                if (unaOveja.GetEsApta())
                {
                    Console.WriteLine($"No. {totalOvejas} - {unaOveja.ToString()}");
                    contadorOvejasAptas++;
                }
                totalOvejas++;
            }
            Console.WriteLine($"De las {cantidadOvejas} Ovejas, {contadorOvejasAptas} son aptas");
        }
            */
        }
    }
}

