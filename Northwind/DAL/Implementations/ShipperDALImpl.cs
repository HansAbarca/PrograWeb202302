using DAL.Interfaces;
using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
            try
            {
                string sql="exec [dbo].[sp_AddShipper] @CompanyName";
                var param = new SqlParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = "@CompanyName",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = entity.CompanyName
                    },
                };

                NorthWindContext northWindContext = new NorthWindContext();
                int resultado = northWindContext.Database.ExecuteSqlRaw(sql, param);

                return true;
            }
            catch (Exception)
            {
                // Manejo de la excepción
                return false;
            }
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
        public async Task<Shipper> Get(int id)
        {
            Shipper Shipper = null;
            using (unidad = new UnidadDeTrabajo<Shipper>(new NorthWindContext()))
            {
                Shipper = await unidad.genericDAL.Get(id);
            }
            return Shipper;
        }
        public async Task<IEnumerable<Shipper>> GetAll()
        {
            List<Shipper> shippers = new List<Shipper>();
            List<sp_GetAllShippers_Result> resultado;
            string sql = "[dbo].[sp_GetAllShippers]";
            NorthWindContext northWindContext = new NorthWindContext();

            resultado = await northWindContext.sp_GetAllShippers_Results
                .FromSqlRaw(sql)
                .ToListAsync();

            foreach (var item in resultado)
            {
                shippers.Add(
                    new Shipper
                    {
                        ShipperId = item.ShipperId,
                        CompanyName = item.CompanyName,
                        Phone = item.Phone
                    }

                    );
            }

            /*            using (unidad = new UnidadDeTrabajo<Shipper>(new NorthWindContext()))
                        {
                            categories =  await unidad.genericDAL.GetAll();
                        }*/
            return shippers;
        }
        #endregion
        #region Remove
        public bool Remove(Shipper entity)
        {
            try
            {
                // Código donde se puede generar una excepción
                using (unidad = new UnidadDeTrabajo<Shipper>(new NorthWindContext()))
                {
                    unidad.genericDAL.Remove(entity);
                    unidad.Complete();
                }

                return true;
            }
            catch (Exception)
            {
                // Manejo de la excepción
                return false;
            }
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
            try
            {
                // Código donde se puede generar una excepción
                using (unidad = new UnidadDeTrabajo<Shipper>(new NorthWindContext()))
                {
                    unidad.genericDAL.Update(entity);
                    unidad.Complete();
                }

                return true;
            }
            catch (Exception)
            {
                // Manejo de la excepción
                return false;
            }
        }
        #endregion
    }
}
