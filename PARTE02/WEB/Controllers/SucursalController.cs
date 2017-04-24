using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB.Controllers
{
    public class SucursalController : Controller
    {
        //
        // GET: /Sucursal/
        public ActionResult Index()
        {
            Sucursal a = new Sucursal();

            return View(a.listar());
        }

        public ActionResult ListarOrdenPago(int id)
        {


            return RedirectToAction("Index", "OrdenPago", new { idSucursal = id });

        }

        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit(int id)
        {
            Sucursal a = new Sucursal();

            Banco b = new Banco();
            
            Sucursal response = (Sucursal)a.Editar(id);
            response.Bancos= b.listar();

            ViewBag.Banco_Id = new SelectList(b.listar(),"IdBanco","Nombre",response.idBanco);

            return View(response);
        }
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditPost(Sucursal Sucursal, FormCollection form)
        {
            Sucursal a = new Sucursal();

            Sucursal.idBanco = Convert.ToInt32(form["Banco_Id"].ToString());
            a.actualizar(Sucursal);

            return RedirectToAction("Index");

        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult DeleteGet(int id)
        {
            Sucursal a = new Sucursal();

            a.eliminar(id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        [ActionName("Create")]
        public ActionResult CreateGet()
        {
            Sucursal sucursal = new Sucursal();
            Banco a = new Banco();
            sucursal.Bancos = a.listar();

            return View(sucursal);
        }
        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreatePost(Sucursal Sucursal, FormCollection form)
        {

            Sucursal a = new Sucursal();
            Sucursal.idBanco = Convert.ToInt32(form["Bancos"].ToString());
            
            a.insert(Sucursal);

            return RedirectToAction("Index");
        }

    }
}
