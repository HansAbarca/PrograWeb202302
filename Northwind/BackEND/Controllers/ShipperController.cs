using BackEND.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private IShipperDAL shipperDAL;

        private ShipperModel Convertir(Shipper shipper)
        {
            return new ShipperModel
            {
                ShipperId = shipper.ShipperId,
                CompanyName = shipper.CompanyName
            };
        }

        private Shipper Convertir(ShipperModel shipper)
        {
            return new Shipper
            {
                ShipperId = shipper.ShipperId,
                CompanyName = shipper.CompanyName
            };
        }

        #region Constructores
        public ShipperController()
        {
            shipperDAL = new ShipperDALImpl();
        }
        #endregion
        #region Consultas
        // GET: api/<ShipperController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Shipper> categories = shipperDAL.GetAll();
            List<ShipperModel> ship = new List<ShipperModel>();

            foreach (var category in categories)
            {
                ship.Add(Convertir(category));
            }

            return new JsonResult(ship);
        }

        // GET api/<ShipperController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Shipper shipper = shipperDAL.Get(id);

            return new JsonResult(Convertir(shipper));
        }
        #endregion
        #region Agregar
        // POST api/<ShipperController>
        [HttpPost]
        public JsonResult Post([FromBody]ShipperModel shipper)
        {
            shipperDAL.Add(Convertir(shipper));
            return new JsonResult(shipper);

        }
        #endregion
        #region Modificar
        // PUT api/<ShipperController>/5
        [HttpPut]
        public JsonResult Put([FromBody] ShipperModel shipper)
        {
            shipperDAL.Update(Convertir(shipper));
            return new JsonResult(shipper);
        }
        #endregion
        #region Eliminar
        // DELETE api/<ShipperController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        #endregion
    }
}
