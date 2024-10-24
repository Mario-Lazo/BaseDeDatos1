using Microsoft.AspNetCore.Mvc;
using BaseDeDatos1.Datos;  // Referencia a la clase TipoCambioDatos
using BaseDeDatos1.Models;  // Referencia al modelo TipoCambioModel

namespace BaseDeDatos1.Controllers
{
    public class TipoCambioController : Controller
    {
        // Referencia a la clase TipoCambioDatos para manejar las operaciones CRUD
        private Datos.TipoCambioDatos _tipoCambioDatos = new Datos.TipoCambioDatos();

        [Route("tipocambio")]

        // Acción para listar los tipos de cambio
        public IActionResult Index()
        {
            var listaTiposCambio = _tipoCambioDatos.Listar(); // Llamamos al método Listar de TipoCambioDatos
            return View(listaTiposCambio);  // Devolvemos la lista a la vista
        }

        // Acción para mostrar la vista de creación de un tipo de cambio
        public IActionResult Create()
        {
            return View();
        }

        // Acción para recibir los datos del formulario y guardar el tipo de cambio
        [HttpPost]
        public IActionResult Create(Models.TipoCambioModel tipoCambio)
        {
            if (ModelState.IsValid)  // Verificamos si el modelo es válido
            {
                var respuesta = _tipoCambioDatos.Guardar(tipoCambio);  // Llamamos al método Guardar
                if (respuesta)
                {
                    return RedirectToAction("Index");  // Redirigimos a la lista de tipos de cambio si todo fue bien
                }
                else
                {
                    ViewBag.Error = "Ocurrió un error al guardar.";
                }
            }
            return View(tipoCambio);
        }

        // Acción para mostrar la vista de edición de un tipo de cambio
        public IActionResult Edit(int id)
        {
            var tipoCambio = _tipoCambioDatos.Obtener(id);  // Llamamos al método Obtener para traer los datos del tipo de cambio
            return View(tipoCambio);  // Devolvemos los datos del tipo de cambio a la vista de edición
        }

        // Acción para actualizar los datos de un tipo de cambio
        [HttpPost]
        public IActionResult Edit(Models.TipoCambioModel tipoCambio)
        {
            if (ModelState.IsValid)
            {
                var respuesta = _tipoCambioDatos.Modificar(tipoCambio);  // Llamamos al método Modificar
                if (respuesta)
                {
                    return RedirectToAction("Index");  // Redirigimos a la lista de tipos de cambio si todo fue bien
                }
                else
                {
                    ViewBag.Error = "Ocurrió un error al modificar.";
                }
            }
            return View(tipoCambio);
        }

        // Acción para mostrar la vista de confirmación de eliminación de un tipo de cambio
        public IActionResult Delete(int id)
        {
            var tipoCambio = _tipoCambioDatos.Obtener(id);  // Llamamos al método Obtener para traer los datos del tipo de cambio
            return View(tipoCambio);
        }

        // Acción para eliminar un tipo de cambio
        [HttpPost]
        public IActionResult Delete(Models.TipoCambioModel tipoCambio)
        {
            var respuesta = _tipoCambioDatos.Eliminar(tipoCambio.Id);  // Llamamos al método Eliminar
            if (respuesta)
            {
                return RedirectToAction("Index");  // Redirigimos a la lista de tipos de cambio si todo fue bien
            }
            else
            {
                ViewBag.Error = "Ocurrió un error al eliminar.";
            }
            return View(tipoCambio);
        }
    }
}