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

        #region
        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            var todos = _unidadTrabajo.Bodega.ObtenerTodos();
            return Json(new { data = todos });
        }

        public IActionResult Upsert(int? id)
        {
            Bodega bodega = new Bodega();

            if(id == null)
            {
                return View(bodega); //crear un nuevo registro

            }
            //para actualizar
            bodega = _unidadTrabajo.Bodega.Obtener(id.GetValueOrDefault());

            if(bodega == null)
            {
                return NotFound();
            }

            return View(bodega);
        }

        #endregion
    }
}
