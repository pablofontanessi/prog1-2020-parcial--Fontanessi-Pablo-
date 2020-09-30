using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1
{
    public class Normal : Envio
    {
        public override double GenerarCostoEnvio()
        {
            
            return 10.25 * VolumenPaquete + 5.75 * Peso;
            
        }

        public override DateTime GenerarFechaEntrega()
        {
            return FechaEntrega = FechaIngreso.AddDays(3);
        }
    }
}
