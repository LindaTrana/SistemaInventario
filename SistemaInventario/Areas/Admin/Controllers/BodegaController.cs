using Microsoft.AspNetCore.Mvc;
using SistemaInventario.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventario.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaInventario.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BodegaController : Controller
    {

        private readonly IUnidadTrabajo _unidadTrabajo;

        public BodegaController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Upsert(int? id)
        {
            Bodega bodega = new Bodega();

            if (id == null)
            {
                return View(bodega); //crear un nuevo registro

            }
            //para actualizar
            bodega = _unidadTrabajo.Bodega.Obtener(id.GetValueOrDefault());

            if (bodega == null)
            {
                return NotFound();
            }

            return View(bodega);
        }

        #region

        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            var todos = _unidadTrabajo.Bodega.ObtenerTodos();
            return Json(new { data = todos });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Bodega bodega)
        {
            if (ModelState.IsValid)
            {
                if (bodega.Id == 0)
                {
                    _unidadTrabajo.Bodega.Agregar(bodega);
                }
                else
                {
                    _unidadTrabajo.Bodega.Actualizar(bodega);
                }

                _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            return View(bodega);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var bodegaDb = _unidadTrabajo.Bodega.Obtener(id);
            if (bodegaDb == null)
            {
                return Json(new { success = false, message="No se encontro el dato" });
            }
            _unidadTrabajo.Bodega.Remover(bodegaDb);
            _unidadTrabajo.Guardar();
            return Json(new { success = true, message="Se ha borrado el registro"});
        }

        #endregion


    }
}
