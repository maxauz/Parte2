using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace Api.Controllers
{
    public class OrdenPagoController : ApiController
    {
        [Route("api/OrdenPago/{Sucursal}/{TipoMoneda}")]
        public IEnumerable<OrdenPago> GetOrdenPago(string Sucursal,string TipoMoneda)
        {


            OrdenPago op = new OrdenPago();

            return op.listarServicioOrdenPagoPorSucursalTipoMoneda(Sucursal, TipoMoneda);

  
            
            
        }

    }
}
