using Pichonweb2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pichonweb2.Controllers
{
    public class DirecciónController : Controller
    {
        // GET: Dirección
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Select()
        {
            var resp = DirecciónRepository.GetAll();
            return Json(resp, JsonRequestBehavior.AllowGet);

        }

        public ActionResult delete(int Id)
        {
            var resp = DirecciónRepository.DeleteById(Id);
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetById(int ID)
        {
            var resp = DirecciónRepository.GetById(ID);
            return Json(resp, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Insert(int idCliente, string Calle, string Numero, int CP, int idMunicipio, int idEstado)
        {
            var resp = DirecciónRepository.Insert(idCliente, Calle, Numero, CP, idMunicipio, idEstado);
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        public ActionResult update(int idDirección, int idCliente, string Calle, string Numero, int CP, int idMunicipio, int idEstado)
        {
            {
                var resp = DirecciónRepository.Update(idDirección, idCliente, Calle, Numero, CP, idMunicipio, idEstado);
                return Json("OK", JsonRequestBehavior.AllowGet);
            }

        }
    }
}