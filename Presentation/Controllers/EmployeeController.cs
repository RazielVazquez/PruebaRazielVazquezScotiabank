using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Business; // Asegúrate de que este espacio de nombres sea correcto

namespace Presentation.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            var result = Employee.GetEmployees();
            if ((bool)result["Resultado"])
            {
                var employees = (List<Model.Employee>)result["Empleados"];
                return View(employees);
            }
            else
            {
                ViewBag.Error = result["Excepcion"].ToString();
                return View(new List<Model.Employee>());
            }
        }

        [HttpPost]
        public ActionResult Create(Model.Employee newEmployee)
        {
            var result = Employee.AddEmployee(newEmployee);
            return Json(result);
        }

        // Acción para eliminar un empleado
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = Employee.DeleteEmployee(id);
            return Json(result);
        }

        public ActionResult Edit(int id)
        {
            var result = Employee.GetEmployeeById(id); // Debes implementar este método en tu clase Business
            if ((bool)result["Resultado"])
            {
                Model.Employee employee = (Model.Employee)result["Empleado"];
                return View(employee); // Devuelve la vista con el empleado
            }
            else
            {
                ViewBag.Error = result["Excepcion"].ToString();
                return RedirectToAction("Index");
            }
        }

        // Acción para procesar la edición del empleado
        [HttpPost]
        public ActionResult Edit(Model.Employee updatedEmployee)
        {
            var result = Employee.UpdateEmployee(updatedEmployee); // Debes implementar este método en tu clase Business
            return Json(result);
        }
    }
}
