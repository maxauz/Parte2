using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WEB.Controllers
{
    public class OrdenPagoController : Controller
    {
        //
        // GET: /OrdenPago/
      
        public ActionResult Index(int idSucursal)
        {
            OrdenPago ordenPago = new OrdenPago();

           
            ViewBag.idSucursal = idSucursal;

            return View(ordenPago.listar(idSucursal));
        }

        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit(int id)
        {
            OrdenPago op = new OrdenPago();
           

            OrdenPago ordenPago=op.Editar(id);
            List<SelectListItem> ls = new List<SelectListItem>();
            SelectListItem soles = new SelectListItem();
            soles.Value = "s";
            soles.Text = "S/.";
            ls.Add(soles);
            SelectListItem dolares = new SelectListItem();
            dolares.Value = "d";
            dolares.Text = "$.";
            ls.Add(dolares);

            ViewBag.Moneda = new SelectList(ls, "Value", "Text",ordenPago.Moneda);

            List<SelectListItem> lsEstado = new List<SelectListItem>();

            SelectListItem pagada = new SelectListItem();
            pagada.Value = "p";
            pagada.Text = "Pagada";
            lsEstado.Add(pagada);

            SelectListItem declinada = new SelectListItem();
            declinada.Value = "d";
            declinada.Text = "Declinada";
            lsEstado.Add(declinada);

                       SelectListItem fallida = new SelectListItem();
            fallida.Value = "f";
            fallida.Text = "Fallida";
            lsEstado.Add(fallida);

            SelectListItem anulada = new SelectListItem();
            anulada.Value = "a";
            anulada.Text = "Anulada";
            lsEstado.Add(anulada);


            ViewBag.Estado = new SelectList(lsEstado, "Value", "Text",ordenPago.Estado);

            return View(ordenPago);
        }
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditPost(OrdenPago ordenPago, FormCollection form)
        {
            OrdenPago op = new OrdenPago();

            ordenPago.Moneda = Convert.ToString(form["Moneda"].ToString());

            ordenPago.Estado = Convert.ToString(form["Estado"].ToString());
            op.actualizar(ordenPago);

            return RedirectToAction("Index", new { idSucursal = ordenPago.idSucursal });

        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create(int idSucursal)
        {
            
            OrdenPago op = new OrdenPago();
            op.idSucursal=idSucursal;
            List<SelectListItem> ls = new List<SelectListItem>();
             SelectListItem soles = new SelectListItem();
             soles.Value = "s";
             soles.Text = "S/.";
             ls.Add(soles);
             SelectListItem dolares = new SelectListItem();
             dolares.Value = "d";
             dolares.Text = "$.";
             ls.Add(dolares);

            ViewBag.Moneda = new SelectList(ls, "Value", "Text");
            return View(op);
        }
        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreatePost(OrdenPago ordenPago)
        {
     

            OrdenPago op = new OrdenPago();

            op.insert(ordenPago);


            return RedirectToAction("Index", new { idSucursal=ordenPago.idSucursal });
        }


        [HttpGet]
        [ActionName("Delete")]
        public ActionResult DeleteGet(int id, int idSucursal)
        {
            OrdenPago op = new OrdenPago();
            op.eliminar(id);

            return RedirectToAction("Index", new { idSucursal = idSucursal });
        }

    }
}
