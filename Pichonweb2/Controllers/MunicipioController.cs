using Pichonweb2.Models;
using Pichonweb2.Repository;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Pichonweb2.Controllers
{
    public class MunicipioController : Controller
    {
        // GET: Municipio
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Select()
        {
            List<Municipio> municipios = MunicipioRepository.GetAll();
            List<Estado> estados = EstadoRepository.GetAll();

            foreach (Municipio M in municipios)
            {
                string estado = M.idEstado;
                foreach (Estado E in estados)
                {
                    string idE = E.idEstado;
                    if (estado == idE)
                    {
                        M.idEstado = E.Nombre;
                    }
                }
            }    
            return Json(municipios, JsonRequestBehavior.AllowGet);
        }

        public ActionResult delete(int Id)
        {
            var resp = MunicipioRepository.DeleteById(Id);
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetById(int ID)
        {
            var resp = MunicipioRepository.GetById(ID);
            return Json(resp, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Insert(string Nombre, int idEstado)
        {
            var resp = MunicipioRepository.Insert(Nombre, idEstado);
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        public ActionResult update(int idMunicipio,string Nombre, int idEstado)
        {
            var resp = MunicipioRepository.Update(idMunicipio, Nombre, idEstado);
            return Json("OK", JsonRequestBehavior.AllowGet);
        }
    }
}