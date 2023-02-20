using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.AccesoDatos.Repositorio.IRepositorio
{
    public interface IRepositorio<T> where T: class
    {
        T Obtener(int Id);

        IEnumerable<T> ObtenerTodos(
            Expression <Func<T, bool>> filter=null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy= null,
            string IncluirPropiedades=null
            );

        T ObtenerPrimero(
            Expression<Func<T, bool>> filter = null,
            string IncluirPropiedades = null
            );

        void Agregar(T entidad);
        void Remover(int Id);
        void Remover (T entidad);
        void RemoverRango (IEnumerable<T> entidad);


    }
}
