using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1
{
    class Principal
    {
        List<Envio> ListaEnvios = new List<Envio>();
        List<Cliente> ListaClientes = new List<Cliente>(); 

        public void RegistrarNuevoEnvio(string TipoEnvio, int CodigoPostalOrigen, int CodigoPostalDestino, double VolumenPaquete, double PesoPaquete, string NombreCliente)
        {
            //DUPLICA MUCHO CODIGO
            switch (TipoEnvio)
            {
                case "Normal":
                    Normal NuevoEnvio = new Normal();
                    NuevoEnvio.CodigoPostalOrigen = CodigoPostalOrigen;
                    NuevoEnvio.CodigoPostalDestino = CodigoPostalDestino;
                    NuevoEnvio.VolumenPaquete = VolumenPaquete;
                    NuevoEnvio.Peso = PesoPaquete;
                    NuevoEnvio.CodigoSeguimiento = NuevoEnvio.CodigoSeguimientoValido(ListaEnvios);
                    NuevoEnvio.FechaIngreso = DateTime.Today;
                    NuevoEnvio.FechaEntrega = NuevoEnvio.GenerarFechaEntrega();
                    NuevoEnvio.CostoEnvio = NuevoEnvio.GenerarCostoEnvio();
                    NuevoEnvio.NombreCliente = NombreCliente;
                    break;
                case "Fragil":
                    Fragil NuevoEnvioFragil = new Fragil();
                    NuevoEnvioFragil.CodigoPostalOrigen = CodigoPostalOrigen;
                    NuevoEnvioFragil.CodigoPostalDestino = CodigoPostalDestino;
                    NuevoEnvioFragil.VolumenPaquete = VolumenPaquete;
                    NuevoEnvioFragil.Peso = PesoPaquete;
                    NuevoEnvioFragil.CodigoSeguimiento = NuevoEnvioFragil.CodigoSeguimientoValido(ListaEnvios);
                    NuevoEnvioFragil.FechaIngreso = DateTime.Today;
                    NuevoEnvioFragil.FechaEntrega = NuevoEnvioFragil.GenerarFechaEntrega();
                    NuevoEnvioFragil.CostoEnvio = NuevoEnvioFragil.GenerarCostoEnvio();
                    break;
                case "Prioritario":
                    Prioritario NuevoEnvioPrioritario = new Prioritario();
                    NuevoEnvioPrioritario.CodigoPostalOrigen = CodigoPostalOrigen;
                    NuevoEnvioPrioritario.CodigoPostalDestino = CodigoPostalDestino;
                    NuevoEnvioPrioritario.VolumenPaquete = VolumenPaquete;
                    NuevoEnvioPrioritario.Peso = PesoPaquete;
                    NuevoEnvioPrioritario.CodigoSeguimiento = NuevoEnvioPrioritario.CodigoSeguimientoValido(ListaEnvios);
                    NuevoEnvioPrioritario.FechaIngreso = DateTime.Today;
                    NuevoEnvioPrioritario.FechaEntrega = NuevoEnvioPrioritario.GenerarFechaEntrega();
                    NuevoEnvioPrioritario.CostoEnvio = NuevoEnvioPrioritario.GenerarCostoEnvio();
                    break;
                default:
                    break;
            }

        }

        public List<ListadoEnvio> ObtenerListadoEnviosPorCliente(Cliente Clientes)
        {
            List<ListadoEnvio> ListaFiltrada = new List<ListadoEnvio>();
            foreach (var envio in ListaEnvios)
            {
                if (envio.NombreCliente == Clientes.NombreCliente)
                {
                    ListadoEnvio NuevoEnvio = new ListadoEnvio();
                    NuevoEnvio.NombreCliente = envio.NombreCliente;
                    NuevoEnvio.FechaIngreso = envio.FechaIngreso;
                    if (envio.FechaEntrega < DateTime.Today)
                    {
                        NuevoEnvio.Entregado = true;
                    }
                    else
                    {
                        NuevoEnvio.Entregado = false;
                    }
                    ListaFiltrada.Add(NuevoEnvio);
                }

            }
            ListaFiltrada = ListaFiltrada.OrderByDescending(x => x.FechaIngreso).ToList();
            return ListaFiltrada;
        }


        //NO MAXIMIZA GANANCIAS PORQ NO CUENTA CANTIDAD DE PAQUETES
        public List<Envio> ObtenerMaximoListaEnvio(List<Envio> ListaEnvio, double PesoMax, double VolumenMax)
        {
            List<Envio> ListaEnviosMaxGanancia = new List<Envio>();
            List<Envio> EnviosOrdenadosPorPrecio = ListaEnvios.OrderByDescending(x => x.CostoEnvio).ToList();
            double PesoAcumulado = 0;
            double VolumenAcumulado = 0;
           
            foreach (var envio in EnviosOrdenadosPorPrecio)
            {
                if ((envio.Peso+PesoAcumulado) <=PesoMax && (envio.VolumenPaquete + VolumenAcumulado)<= VolumenMax)
                {
                    PesoAcumulado += envio.Peso;
                    VolumenAcumulado += envio.VolumenPaquete;
                    ListaEnviosMaxGanancia.Add(envio);
                }
            }
            return ListaEnviosMaxGanancia;
        }
    }
}
