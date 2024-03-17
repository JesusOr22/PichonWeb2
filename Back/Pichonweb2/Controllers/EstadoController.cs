using Pichonweb2.Repository;
using System.Web.Mvc;

namespace Pichonweb2.Controllers
{
    public class EstadoController : Controller
    {
        // GET: Estado
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Select()
        {
            var resp = EstadoRepository.GetAll();
            return Json(resp, JsonRequestBehavior.AllowGet);
        }

        public ActionResult delete(int Id)
        {
            var resp = EstadoRepository.DeleteById(Id);
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetById(int ID)
        {
            var resp = EstadoRepository.GetById(ID);
            return Json(resp, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Insert(string Nombre)
        {
            var resp = EstadoRepository.Insert(Nombre);
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        public ActionResult update(int idEstado, string Nombre)
        {
            var resp = EstadoRepository.Update(idEstado, Nombre);
            return Json("OK", JsonRequestBehavior.AllowGet);
        }
    }
}
   