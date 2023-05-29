using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ShipperDALImpl : IShipperDAL
    {
        private NorthWindContext _northWindContext;
        private UnidadDeTrabajo<Shipper> unidad;
        #region Add
        public bool Add(Shipper entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Shipper> entities)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Find
        public IEnumerable<Shipper> Find(Expression<Func<Shipper, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region get
        public Shipper Get(int id)
        {
            Shipper Shipper = null;
            using (unidad = new UnidadDeTrabajo<Shipper>(new NorthWindContext()))
            {
                Shipper = unidad.genericDAL.Get(id);
            }
            return Shipper;
        }
        public IEnumerable<Shipper> GetAll()
        {
            IEnumerable<Shipper> categories = null;
            using (unidad = new UnidadDeTrabajo<Shipper>(new NorthWindContext()))
            {
                categories = unidad.genericDAL.GetAll();
            }
            return categories;
        }
        #endregion
        #region Remove
        public bool Remove(Shipper entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Shipper> entities)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Single
        public Shipper SingleOrDefault(Expression<Func<Shipper, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Update
        public bool Update(Shipper entity)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
