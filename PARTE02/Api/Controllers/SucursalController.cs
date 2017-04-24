using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class SucursalController : ApiController
    {
        [Route("api/Sucursal/{NombreBanco}")]
        public List<Sucursal> GetOrdenPago(string NombreBanco)
        {


            Sucursal s = new Sucursal();

            return s.listarSucursalXNombreBanco(NombreBanco);




        }
    }
}
