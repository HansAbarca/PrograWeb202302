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
    }
}
