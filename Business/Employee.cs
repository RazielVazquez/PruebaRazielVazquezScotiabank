using Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Employee
    {
        public static Dictionary<string, object> GetEmployees()
        {
            Dictionary<string, object> diccionario = new Dictionary<string, object>
            {
                { "Resultado", false },
                { "Empleados", new List<Model.Employee>() },
                { "Excepcion", "" }
            };

            try
            {
                using (var context = new EmployeeContext())
                {
                    var employees = context.Employees.ToList();

                    if(employees != null)
                    {
                        diccionario["Empleados"] = employees;
                        diccionario["Resultado"] = true;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;
            }

            return diccionario;
        }

        public static Dictionary<string, object> AddEmployee(Model.Employee newEmployee)
        {
            Dictionary<string, object> diccionario = new Dictionary<string, object>
            {
                { "Resultado", false },
                { "Excepcion", "" }
            };

            try
            {
                using (var context = new EmployeeContext())
                {
                    context.Employees.Add(newEmployee);
                    context.SaveChanges();
                    diccionario["Resultado"] = true;
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;
            }

            return diccionario;
        }

        public static Dictionary<string, object> DeleteEmployee(int employeeId)
        {
            Dictionary<string, object> diccionario = new Dictionary<string, object>
    {
        { "Resultado", false },
        { "Excepcion", "" }
    };

            try
            {
                using (var context = new EmployeeContext())
                {
                    var employee = context.Employees.Find(employeeId);
                    if (employee != null)
                    {
                        context.Employees.Remove(employee);
                        context.SaveChanges();
                        diccionario["Resultado"] = true;
                    }
                    else
                    {
                        diccionario["Excepcion"] = "Empleado no encontrado.";
                    }
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;
            }

            return diccionario;
        }

        public static Dictionary<string, object> GetEmployeeById(int employeeId)
        {
            Dictionary<string, object> diccionario = new Dictionary<string, object>
    {
        { "Resultado", false },
        { "Empleado", null },
        { "Excepcion", "" }
    };

            try
            {
                using (var context = new EmployeeContext())
                {
                    var employee = context.Employees.Find(employeeId);
                    if (employee != null)
                    {
                        diccionario["Empleado"] = employee;
                        diccionario["Resultado"] = true;
                    }
                    else
                    {
                        diccionario["Excepcion"] = "Empleado no encontrado.";
                    }
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;
            }

            return diccionario;
        }

        public static Dictionary<string, object> UpdateEmployee(Model.Employee updatedEmployee)
        {
            Dictionary<string, object> diccionario = new Dictionary<string, object>
    {
        { "Resultado", false },
        { "Excepcion", "" }
    };

            try
            {
                using (var context = new EmployeeContext())
                {
                    var employee = context.Employees.Find(updatedEmployee.Id); // Asegúrate de que tu modelo tiene la propiedad Id
                    if (employee != null)
                    {
                        // Actualiza las propiedades del empleado
                        employee.FirstName = updatedEmployee.FirstName;
                        employee.LastName = updatedEmployee.LastName;
                        employee.Email = updatedEmployee.Email;
                        employee.DateOfBirth = updatedEmployee.DateOfBirth;
                        employee.Position = updatedEmployee.Position;

                        context.SaveChanges();
                        diccionario["Resultado"] = true;
                    }
                    else
                    {
                        diccionario["Excepcion"] = "Empleado no encontrado.";
                    }
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;
            }

            return diccionario;
        }


    }
}
