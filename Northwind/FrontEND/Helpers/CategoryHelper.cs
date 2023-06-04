using FrontEND.Models;
using Newtonsoft.Json;

namespace FrontEND.Helpers
{
    public class CategoryHelper
    {
        ServiceRepository repository;
        public CategoryHelper()
        {
            repository = new ServiceRepository();
        }

        public List<CategoryViewModel> GetAll()
        {

            List<CategoryViewModel> lista = new List<CategoryViewModel>();
            HttpResponseMessage responseMessage = repository.GetResponse("api/Category/");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<CategoryViewModel>>(content);
            }

            return lista;
        }

    }
}
