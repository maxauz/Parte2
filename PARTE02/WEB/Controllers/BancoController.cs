using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB.Controllers
{
    public class BancoController : Controller
    {
        //
        // GET: /Banco/

        public ActionResult Index()
        {
            Banco a = new Banco();

            return View(a.listar());
        }
        [HttpGet]
        [ActionName("Edit")]
        public ActionResult EditGet(int id) {
            Banco a = new Banco();
          

            return View(a.Editar(id));
        }
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditPost(Banco banco)
        {
            Banco a = new Banco();
            a.actualizar(banco);

            return RedirectToAction("Index");
            
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult DeleteGet(int id)
        {
            Banco a = new Banco();

            a.eliminar(id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        [ActionName("Create")]
        public ActionResult CreateGet() {
            return View();
        }
        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreatePost(Banco banco)
        {

            Banco a = new Banco();
            a.insert(banco);
          
            return RedirectToAction("Index");
        }

    }
}
