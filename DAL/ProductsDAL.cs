using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;
using System.Net;
using System.Net.Http;
using KAMM_FARM_SERVICES.DAL.DAL_Properties;
using Newtonsoft.Json;

namespace KAMM_FARM_SERVICES.DAL
{
    public class ProductsDAL
    {
        private ProductsProps product;
        HttpClient client = new HttpClient();

        public ProductsDAL(ProductsProps product_prop)
        {
            product = product_prop;
        }

        public async Task<bool> Create_product()
        {
            bool success = false;
            try
            {
                //Posting to online server
                string derived_uri = Env.live_url + "/Create_product/" + product.category + "/";
                var stringPayload = JsonConvert.SerializeObject(product);

                // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
                var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(derived_uri, httpContent);

                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    dynamic response_content = await response.Content.ReadAsStringAsync();
                    dynamic deserialized = JsonConvert.DeserializeObject(response_content);
                    MessageBox.Show(deserialized.ToString());
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            return success;
        }

        public static async Task<dynamic> Fetch_categories()
        {
            HttpClient client = new HttpClient();

            try
            {
                //Posting to online server
                string derived_uri = Env.live_url + "/Get_All_Products";

                // Wrap our JSON inside a StringContent which then can be used by the HttpClient class

                HttpResponseMessage response = await client.GetAsync(derived_uri);

                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    dynamic response_content = await response.Content.ReadAsStringAsync();
                    dynamic deserialized = JsonConvert.DeserializeObject(response_content);
                    //MessageBox.Show(deserialized.ToString());
                    return deserialized;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            return null;
        }



    }
}
