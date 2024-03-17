using Pichonweb2.Models;
using Pichonweb2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pichonweb2.Controllers
{
    public class ContratosController : Controller
    {
        // GET: Contratos
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Select()
        {
            List<Contratos> contratos = ContratosRepository.GetAll();
            List<Dirección> direcciones = DirecciónRepository.GetAll();
            List<Estado> estados = EstadoRepository.GetAll();

            foreach (Contratos C in contratos)
            {
                string direccion = C.idDirección;
                foreach (Dirección D in direcciones)
                {
                    string idD = D.idDirección;
                    if (direccion == idD)
                    {
                        C.idDirección = D.Calle;
                    }
                }
                string estado = C.idEstado;
                foreach (Estado E in estados)
                {
                    string idE = E.idEstado;
                    if (estado == idE)
                    {
                        C.idEstado = E.Nombre;
                    }
                }
            }
                return Json(contratos, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult delete(int Id)
        {
            var resp = ContratosRepository.DeleteById(Id);
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetById(int ID)
        {
            var resp = ContratosRepository.GetById(ID);
            return Json(resp, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Insert(int idCliente, int idDirección, int idMunicipio, int idEstado,string FechaContrato, string FechaEvento, int Anticipo, int Precio, int Horas, string Estatus)
        {
            var resp = ContratosRepository.Insert(idCliente, idDirección, idMunicipio, idEstado, FechaContrato, FechaEvento, Anticipo, Precio, Horas, Estatus);
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(int idContrato, int idCliente, int idDirección, int idMunicipio, int idEstado, string FechaContrato, string FechaEvento, int Anticipo, int Precio, int Horas, string Estatus)
        {
            var resp = ContratosRepository.Update(idContrato, idCliente, idDirección, idMunicipio, idEstado, FechaContrato, FechaEvento, Anticipo, Precio, Horas, Estatus);
            return Json("OK", JsonRequestBehavior.AllowGet);
        }
    }
}