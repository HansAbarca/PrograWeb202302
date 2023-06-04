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

    }
}
