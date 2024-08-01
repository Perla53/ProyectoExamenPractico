using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Empleado empleado = new ML.Empleado();
            return View(empleado);
        }

        [HttpGet]
        public JsonResult GetAllJS()
        {
            ML.Result result = BL.Empleado.GetAll();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Add(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Add(empleado);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Update(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Update(empleado);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetById(int id)
        {
            ML.Result result = BL.Empleado.GetById(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult Delete(int id)
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.Id = id;
            ML.Result result = BL.Empleado.Delete(empleado);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetAllCatEntidadFederativa()
        {
            ML.Result result = BL.CatEntidadFederativa.GetAll();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}