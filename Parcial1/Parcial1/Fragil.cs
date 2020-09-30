using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1
{
    public class Fragil: Envio
    {
        public string TipoEnvioFragil { get; set; }


        public override double GenerarCostoEnvio()
        {
           

            if (TipoEnvioFragil != "Explosivo")
            {
                if (CodigoPostalDestino == CodigoPostalOrigen)
                {
                    return  240;
                }
                else
                {
                    return  240 + (240 * 0.07);
                }
            }
            else
            {
                if (CodigoPostalDestino == CodigoPostalOrigen)
                {
                    return  275;
                }
                else
                {
                    return  275 + (275 * 0.07);
                }
            }

        }
        public override DateTime GenerarFechaEntrega()
        {
            return FechaEntrega = FechaIngreso.AddDays(5);
        }
    }
}
