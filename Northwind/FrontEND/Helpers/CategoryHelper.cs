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
        #region GetALL
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
        #endregion
        #region GetByID
        /// <summary>
        /// Obtener Category by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CategoryViewModel GetByID(int id)
        {
            CategoryViewModel category = new CategoryViewModel(); ;

            HttpResponseMessage responeseMessage = repository.GetResponse("api/Category/" + id);
            var content = responeseMessage.Content.ReadAsStringAsync().Result;

            category = JsonConvert.DeserializeObject<CategoryViewModel>(content);

            return category;

        }

        #endregion
    }
}
