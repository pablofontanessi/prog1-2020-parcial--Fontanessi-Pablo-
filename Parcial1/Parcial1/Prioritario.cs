using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1
{
    public class Prioritario: Envio
    {
        public override double GenerarCostoEnvio()
        {
           

            if (CodigoPostalDestino == CodigoPostalOrigen)
            {
                if (Peso > 5)
                {
                    return 120 + (Peso - 5) * 12.5;
                }
                else
                {
                    return  120;
                }
            }
            else
            {
                if (Peso > 5)
                {
                    return  180 + (Peso - 5) * 12.5;
                }
                else
                {
                    return 180;
                }


            }

        }
        public override DateTime GenerarFechaEntrega()
        {
            if (CodigoPostalDestino == CodigoPostalOrigen)
            {
                if (Peso > 5)
                {
                    int DiasExtas = Convert.ToInt32(Peso)-5;
                    return FechaEntrega = FechaIngreso.AddDays(DiasExtas);
                }
                else
                {
                    return FechaEntrega = FechaIngreso;
                }
            }
            else
            {
                if (Peso > 5)
                {
                    Peso += 1; //Agrego uno para que abajo cuando reste este agregado el dia que tarda al ser de otra ciudad
                    int DiasExtas = Convert.ToInt32(Peso - 5);
                    return FechaEntrega = FechaIngreso.AddDays(DiasExtas);
                    
                }
                else
                {
                    return FechaEntrega = FechaIngreso.AddDays(1);
                }
            }
        }
    }
}
