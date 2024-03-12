using Newtonsoft.Json;
using Pichonweb2.Models;
using Pichonweb2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;

namespace Pichonweb2.Controllers
{
    public class ClientesController : Controller
    {
        //GET: Clientes

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Select()
        {
            var resp = ClientesRepository.GetAll();
            return Json(resp, JsonRequestBehavior.AllowGet);
        }

        public ActionResult delete(int Id)
        {
            var resp = ClientesRepository.DeleteById(Id);
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetById(int ID)
        {
            var resp = ClientesRepository.GetById(ID);
            return Json(resp, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Insert(string Nombre, string ApellidoP, string ApellidoM, string Teléfono)
        {
            var resp = ClientesRepository.Insert(Nombre, ApellidoP, ApellidoM, Teléfono);
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        public ActionResult update(int IdCliente, string Nombre, string ApellidoP, string ApellidoM, string Teléfono)
        {
            var resp = ClientesRepository.Update (IdCliente, Nombre, ApellidoP, ApellidoM, Teléfono);
            return Json("OK", JsonRequestBehavior.AllowGet);
        }
    }
}