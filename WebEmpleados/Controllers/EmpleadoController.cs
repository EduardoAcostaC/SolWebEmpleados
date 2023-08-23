using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEmpleados.Datos;
using WebEmpleados.Models;

namespace WebEmpleados.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            List<Empleado> listaEmpleados = new List<Empleado>();
            try
            {
                //Creando objeto de la clase D_Empleado
                D_Empleado empleado = new D_Empleado();
                listaEmpleados = empleado.ObtenerTodos();


            }
            catch (Exception ex)
            {
                TempData["error"] = ex.StackTrace;
                //codigo para guardar el detalle de la excepcion
               //ex.StackTrace
            }

            return View("Consulta", listaEmpleados);
        }

        public ActionResult IrFormulario()
        {
            return View("VistaFormulario");
        }

        public ActionResult FormularioPOST( Empleado objEmpleado)
        {
            D_Empleado datos = new D_Empleado();
            datos.AgregarEmpleado(objEmpleado);

            TempData["mensaje"] = $"El empleado con id {objEmpleado.idEmpleado} has sido agregado de la base de datos";
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(Empleado empleado)
        { 
           D_Empleado datos = new D_Empleado();
            datos.EliminarEmpleado(empleado);

            TempData["mensaje"] = $"El empleado con id {empleado.idEmpleado} has sido eliminado de la base de datos";
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            try
            {
                D_Empleado datos = new D_Empleado();
                Empleado obj = datos.ObtenerEmpleadoPorId(id);
                return View("VistaEditar",obj);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
                throw;
            }
        }

        public ActionResult EditarPOST( Empleado empleado)
        {
            try
            {
                D_Empleado datos = new D_Empleado();
                datos.EditarEmpleado(empleado);
                TempData["mensaje"] = $"El empleado con id {empleado.idEmpleado} ha sido actualizado correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult Busqueda( string busqueda) 
        {
            try
            {
                D_Empleado datos = new D_Empleado();
                List<Empleado> lista = datos.BuscarEmpleado(busqueda);
                return View("Consulta", lista);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                throw ex;
            }
        }

    }
}