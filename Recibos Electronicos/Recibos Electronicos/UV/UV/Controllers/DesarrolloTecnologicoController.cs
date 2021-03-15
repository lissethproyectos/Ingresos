using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UV.Data;
using UV.Models;
using System.Web.Http.Cors;
using System.Net;
using System.Text;
//using System.Web.Http.Cors;


namespace UV.Controllers
{
    [EnableCors (origins:"*", headers:"*", methods:"*")]
    public class DesarrolloTecnologicoController : Controller
    {
        // GET: DesarrolloTecnologico
        public ActionResult Index()
        {
            return View();
        }

        // GET: DesarrolloTecnologico/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DesarrolloTecnologico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DesarrolloTecnologico/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DesarrolloTecnologico/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DesarrolloTecnologico/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DesarrolloTecnologico/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DesarrolloTecnologico/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public JsonResult ListarDatosEmpleado(string tk)
        {
            string Verificador = string.Empty;
            string EMail = string.Empty;
            int posicion = 0;
            RESULTADO objResp = new RESULTADO();
            List<RESULTADO> lstResp = new List<RESULTADO>();
            bool validaToken = ObtenerDataContext.ValidarToken(tk, ref EMail);
            if (validaToken == true)
            {
                var usuario = ObtenerDataContext.ObtenerDatosEmpleado(EMail, ref Verificador);
                if (Verificador == "0")
                {
                    objResp.error = false;
                    objResp.mensaje_error = string.Empty;
                    objResp.usuario = usuario;                    
                    return Json(objResp, JsonRequestBehavior.AllowGet);
                }

                else
                {
                    objResp.error = false;
                    objResp.mensaje_error = string.Empty;
                    objResp.usuario = null;
                    return Json(objResp, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                objResp.error = true;
                objResp.mensaje_error = "error de validacion";
                objResp.usuario = null;
                return Json(objResp, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult ListarDatosDocente(string tk)
        {
            string Verificador = string.Empty;
            string EMail = string.Empty;
            int posicion = 0;
            RESULTADO_DOCENTE objResp = new RESULTADO_DOCENTE();
            List<RESULTADO_DOCENTE> lstResp = new List<RESULTADO_DOCENTE>();
            bool validaToken = ObtenerDataContext.ValidarTokenDocente(tk, ref EMail);
            //EMail = tk;
            if (validaToken == true)
            {
                //EMail=EMail.ToUpper();
                //posicion = EMail.IndexOf("@UNACH.MX");
                //EMail = EMail.Substring(0, posicion);
                var usuario = ObtenerDataContext.ObtenerDatosDocente(EMail, ref Verificador);
                if (Verificador == "0")
                {
                    objResp.error = false;
                    objResp.mensaje_error = string.Empty;
                    objResp.usuario = usuario;
                    return Json(objResp, JsonRequestBehavior.AllowGet);
                }

                else
                {
                    objResp.error = false;
                    objResp.mensaje_error = "CORREO:[" + EMail + "] NO ENCONTRADO"; //string.Empty;
                    objResp.usuario = null;
                    return Json(objResp, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                objResp.error = true;
                objResp.mensaje_error = "TOKEN INVALIDO";
                objResp.usuario = null;
                return Json(objResp, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ListarDatosDocenteAdmivo(string Plaza, string TipoPersonal)
        {
            string Verificador = string.Empty;          
            string valor = string.Empty;
            TipoPersonal = TipoPersonal.ToUpper();



            string headers = Request.Headers.ToString();
            if (headers.Contains("Authorization"))                
                    valor = Request.Headers.GetValues("Authorization").First();

            if (TipoPersonal == "D")
            {
                RESULTADO_EMP_DOCENTE objResp = new RESULTADO_EMP_DOCENTE();

                List<RESULTADO_EMP_DOCENTE> lstResp = new List<RESULTADO_EMP_DOCENTE>();
                if (valor == "eyJOeXAiOiJKV1QiLCJhbGciOiJIUzl1NiJ9")
                {
                    var usuario = ObtenerDataContext.ObtenerDatosDocenteBiblioteca(Plaza, TipoPersonal, ref Verificador);
                    if (Verificador == "0")
                    {
                        objResp.error = false;
                        objResp.message = string.Empty;
                        objResp.data = usuario;
                        lstResp.Add(objResp);
                        var respuesta = from a in lstResp                                    
                                    select new { a.error, a.message, a.data };

                        var firstItem = respuesta.ElementAt(0);
                        return Json(firstItem, JsonRequestBehavior.AllowGet);
                    }

                    else
                    {
                        objResp.error = true;
                        objResp.message = "No existe usuario con las credenciales ingresadas.";
                        objResp.data = null;
                        lstResp.Add(objResp);
                        var respuesta = from a in lstResp
                                    select new { a.error, a.message, a.data };
                        var firstItem = respuesta.ElementAt(0);

                        return Json(firstItem, JsonRequestBehavior.AllowGet);                    }
                }
                else
                {
                    objResp.error = true;
                    objResp.message = "No existe usuario con las credenciales ingresadas.";
                    objResp.data = null;
                    lstResp.Add(objResp);
                    var respuesta = from a in lstResp
                                    select new { a.error, a.message, a.data };
                    var firstItem = respuesta.ElementAt(0);
                    return Json(firstItem, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                RESULTADO_EMP_ADMIVO objRespAdmivo = new RESULTADO_EMP_ADMIVO();
                List<RESULTADO_EMP_ADMIVO> lstRespAdmivo = new List<RESULTADO_EMP_ADMIVO>();


                if (valor == "eyJOeXAiOiJKV1QiLCJhbGciOiJIUzl1NiJ9")
                {
                    var usuario = ObtenerDataContext.ObtenerDatosAdmivoBiblioteca(Plaza, TipoPersonal, ref Verificador);
                    if (Verificador == "0")
                    {
                        objRespAdmivo.error = false;
                        objRespAdmivo.message = string.Empty;
                        objRespAdmivo.data = usuario;
                        lstRespAdmivo.Add(objRespAdmivo);
                        var respuesta = from a in lstRespAdmivo
                                        select new { a.error, a.message, a.data };
                        var firstItem = respuesta.ElementAt(0);
                        return Json(firstItem, JsonRequestBehavior.AllowGet);
                    }

                    else
                    {
                        objRespAdmivo.error = true;
                        objRespAdmivo.message = "No existe usuario con las credenciales ingresadas.";
                        objRespAdmivo.data = null;
                        lstRespAdmivo.Add(objRespAdmivo);
                        var respuesta = from a in lstRespAdmivo
                                        select new { a.error, a.message, a.data };
                        var firstItem = respuesta.ElementAt(0);
                        return Json(firstItem, JsonRequestBehavior.AllowGet);
                    }

                }
                else
                {
                    objRespAdmivo.error = true;
                    objRespAdmivo.message = "No existe usuario con las credenciales ingresadas.";
                    objRespAdmivo.data = null;
                    lstRespAdmivo.Add(objRespAdmivo);
                    var respuesta = from a in lstRespAdmivo
                                    select new { a.error, a.message, a.data };
                    var firstItem = respuesta.ElementAt(0);
                    return Json(firstItem, JsonRequestBehavior.AllowGet);
                }
            }

        }

        //public JsonResult ListarDatosEmpleado(string tk, string Correo)
        //{
        //    string Verificador = string.Empty;
        //    RESULTADO objResp = new RESULTADO();
        //    List<RESULTADO> lstResp = new List<RESULTADO>();

        //    if (ObtenerDataContext.ValidarToken(tk) == 1)
        //    {
        //        var usuario = ObtenerDataContext.ObtenerDatosEmpleado(Correo, ref Verificador);

        //        if (Verificador == "0")
        //        {
        //            objResp.error = false;
        //            objResp.mensaje_error = string.Empty;
        //            objResp.usuario = usuario;
        //            return Json(objResp, JsonRequestBehavior.AllowGet);
        //            //objResp.USUARIO = usuario;

        //        }
        //        //    return Json(usuario, JsonRequestBehavior.AllowGet);
        //        else
        //        {
        //            objResp.error = false;
        //            objResp.mensaje_error = string.Empty;
        //            objResp.usuario = null;
        //            return Json(objResp, JsonRequestBehavior.AllowGet);
        //        }
        //    }

        //    else
        //    {
        //        objResp.error = false;
        //        objResp.mensaje_error = string.Empty;
        //        objResp.usuario = null;
        //        return Json(objResp, JsonRequestBehavior.AllowGet);
        //    }

        //}

        //public JsonResult ValidaAcceso(string tk)
        //{

        //    if (ObtenerDataContext.ValidarToken(tk) == 1)
        //        return Json(true, JsonRequestBehavior.AllowGet);
        //    else
        //        return Json(false, JsonRequestBehavior.AllowGet);

        //}
    }
}
