using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pichonweb2.Models;
using Pichonweb2.Repository;

namespace Pichonweb2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult login(string UserName,string Password)
        {
            User user_ = UserRepository.Login(UserName, Password);
            if (user_ != null)
            {
                if (user_.Activo == true)
                {
                    return Json("OK", JsonRequestBehavior.AllowGet);
                }else
                {
                    return Json("Usuario inactivo", JsonRequestBehavior.AllowGet);
                }
            }else
            {
                return Json("Usuario o Contraseña incorrecto", JsonRequestBehavior.AllowGet);
            }
        }
    }
}