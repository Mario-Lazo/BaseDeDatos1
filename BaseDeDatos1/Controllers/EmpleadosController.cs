using Microsoft.AspNetCore.Mvc;
using BaseDeDatos1.Datos;  // Referencia a la clase EmpleadosDatos
using BaseDeDatos1.Models;  // Referencia al modelo EmpleadosModel

namespace BaseDeDatos1.Controllers
{
    public class EmpleadosController : Controller
    {
        // Referencia a la clase EmpleadosDatos para manejar las operaciones CRUD
        private EmpleadosDatos _empleadosDatos = new EmpleadosDatos();

        // Acción para listar los empleados
        public IActionResult Index()
        {
            var listaEmpleados = _empleadosDatos.Listar(); // Llamamos al método Listar de EmpleadosDatos
            return View(listaEmpleados);  // Devolvemos la lista a la vista
        }

        // Acción para mostrar la vista de creación de un empleado
        public IActionResult Create()
        {
            return View();
        }

        // Acción para recibir los datos del formulario y guardar el empleado
        [HttpPost]
        public IActionResult Create(EmpleadosModel empleado)
        {
            if (ModelState.IsValid)  // Verificamos si el modelo es válido
            {
                var respuesta = _empleadosDatos.Guardar(empleado);  // Llamamos al método Guardar
                if (respuesta)
                {
                    return RedirectToAction("Index");  // Redirigimos a la lista de empleados si todo fue bien
                }
                else
                {
                    ViewBag.Error = "Ocurrió un error al guardar el empleado.";
                }
            }
            return View(empleado);
        }

        // Acción para mostrar la vista de edición de un empleado
        public IActionResult Edit(int id)
        {
            var empleado = _empleadosDatos.Obtener(id);  // Llamamos al método Obtener para traer los datos del empleado
            return View(empleado);  // Devolvemos los datos del empleado a la vista de edición
        }

        // Acción para actualizar los datos de un empleado
        [HttpPost]
        public IActionResult Edit(EmpleadosModel empleado)
        {
            if (ModelState.IsValid)
            {
                var respuesta = _empleadosDatos.Modificar(empleado);  // Llamamos al método Modificar
                if (respuesta)
                {
                    return RedirectToAction("Index");  // Redirigimos a la lista de empleados si todo fue bien
                }
                else
                {
                    ViewBag.Error = "Ocurrió un error al modificar el empleado.";
                }
            }
            return View(empleado);
        }

        // Acción para mostrar la vista de confirmación de eliminación de un empleado
        public IActionResult Delete(int id)
        {
            var empleado = _empleadosDatos.Obtener(id);  // Llamamos al método Obtener para traer los datos del empleado
            return View(empleado);
        }

        // Acción para eliminar un empleado
        [HttpPost]
        public IActionResult Delete(EmpleadosModel empleado)
        {
            var respuesta = _empleadosDatos.Eliminar(empleado.EmpleadoID);  // Llamamos al método Eliminar
            if (respuesta)
            {
                return RedirectToAction("Index");  // Redirigimos a la lista de empleados si todo fue bien
            }
            else
            {
                ViewBag.Error = "Ocurrió un error al eliminar el empleado.";
            }
            return View(empleado);
        }
    }
}
