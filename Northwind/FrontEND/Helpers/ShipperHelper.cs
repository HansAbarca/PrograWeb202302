using FrontEND.Models;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;

namespace FrontEND.Helpers
{
    public class ShipperHelper
    {
        ServiceRepository repository;
        public ShipperHelper()
        {
            repository = new ServiceRepository();
        }
        #region GetAll
        public List<ShipperViewModel> GetAll()
        {

            List<ShipperViewModel> lista = new List<ShipperViewModel>();

            HttpResponseMessage responseMessage = repository.GetResponse("api/Shipper/");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<ShipperViewModel>>(content);
            }

            return lista;
        }
        #endregion
        #region GetID

        public ShipperViewModel GetByID(int id)
        {
            ShipperViewModel ship = new ShipperViewModel();

            HttpResponseMessage responseMessage = repository.GetResponse("api/Shipper/" + id);
            var content = responseMessage.Content.ReadAsStringAsync().Result;

            ship = JsonConvert.DeserializeObject<ShipperViewModel>(content);

            return ship;
        }

        #endregion
        #region Update

        public ShipperViewModel Edit(ShipperViewModel shipper)
        {
            HttpResponseMessage httpResponse = repository.PutResponse("api/Shipper/", shipper);
            var content = httpResponse.Content.ReadAsStringAsync().Result;
            ShipperViewModel shipperAPI = JsonConvert.DeserializeObject<ShipperViewModel>(content);

            return shipperAPI;
        }

        #endregion
        #region Create

        public ShipperViewModel Add(ShipperViewModel shipper)
        {
            HttpResponseMessage httpResponse = repository.PostResponse("api/Shipper/", shipper);
            var content = httpResponse.Content.ReadAsStringAsync().Result;
            ShipperViewModel shipperAPI = JsonConvert.DeserializeObject<ShipperViewModel>(content);

            return shipperAPI;
        }

        #endregion
        #region Delete
        /// <summary>
        /// Eliminar shipper by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ShipperViewModel Delete(int id)
        {
            ShipperViewModel shipper = new ShipperViewModel(); ;

            HttpResponseMessage responeseMessage = repository.DeleteResponse("api/Shipper/" + id);
            // var content = responeseMessage.Content.ReadAsStringAsync().Result;

            // category = JsonConvert.DeserializeObject<CategoryViewModel>(content);

            return shipper;

        }

        #endregion
    }
}
