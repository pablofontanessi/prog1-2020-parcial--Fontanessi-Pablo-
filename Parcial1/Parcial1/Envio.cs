using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1
{
    abstract public class Envio
    {
        public int CodigoPostalOrigen { get; set; }
        public int CodigoPostalDestino { get; set; }
        public int CodigoSeguimiento { get; set; }
        public double VolumenPaquete { get; set; }
        public double Peso { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string NombreCliente { get; set; }
        public double CostoEnvio { get; set; }

        //ESTE METODO DEBERIA SER UNO SOLO
        abstract public DateTime GenerarFechaEntrega();
        abstract public double GenerarCostoEnvio();

        public int GenerarCodigoSeguimiento()
        {
            Random NroAleatorio = new Random();
            int CodigoSeguimiento = NroAleatorio.Next(100000, 999999);
            return CodigoSeguimiento;
        }

        public int CodigoSeguimientoValido(List<Envio> ListaEnvio)
        {
            CodigoSeguimiento = GenerarCodigoSeguimiento();

            int Validador = 0;
            while (Validador == 0)
            {
                foreach (var envio in ListaEnvio)
                {
                    if (envio.CodigoSeguimiento == CodigoSeguimiento)
                    {
                        Validador += 1;
                    }

                }
                if (Validador == 0)
                {
                    return CodigoSeguimiento;
                }
                else
                {
                    Validador = 0;
                    CodigoSeguimiento = GenerarCodigoSeguimiento();
                }
            }
            return 0;
        }
    }
}
