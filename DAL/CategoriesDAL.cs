using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;


namespace KAMM_FARM_SERVICES.DAL
{
    public class CategoriesDAL
    {

        HttpClient client = new HttpClient();

        public async Task<bool> Create_category(string name , string description)
        {
            bool success = false;
            try
            {
                //Posting to online server
                string derived_uri = Env.live_url + "/Create_category/";
                var stringPayload = JsonConvert.SerializeObject(new { name = name, description = description });

                // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
                var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(derived_uri, httpContent);

                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    dynamic response_content = await response.Content.ReadAsStringAsync();
                    dynamic deserialized = JsonConvert.DeserializeObject(response_content);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (HttpRequestException ex) { 
                MessageBox.Show("An error occured . Check your internet connection.");
            }
            finally
            {

            }
            return success;
        }


        public async Task<bool> Update_category(string name, string description , int id)
        {
            bool success = false;
            try
            {
                //Posting to online server
                string derived_uri = Env.live_url + "/Update_category/" + id + "/";
                var stringPayload = JsonConvert.SerializeObject(new { name = name, description = description });

                // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
                var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync(derived_uri, httpContent);

                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    dynamic response_content = await response.Content.ReadAsStringAsync();
                    dynamic deserialized = JsonConvert.DeserializeObject(response_content);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (HttpRequestException ex) { 
                MessageBox.Show("An error occured . Check your internet connection.");
            }
            finally
            {

            }
            return success;
        }

        public async Task<bool> Delete_category(int id)
        {
            bool success = false;
            try
            {
                //Posting to online server
                string derived_uri = Env.live_url + "/Delete_category/" + id + "/";

                // Wrap our JSON inside a StringContent which then can be used by the HttpClient class

                HttpResponseMessage response = await client.DeleteAsync(derived_uri);

                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    dynamic response_content = await response.Content.ReadAsStringAsync();
                    dynamic deserialized = JsonConvert.DeserializeObject(response_content);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (HttpRequestException ex) { 
                MessageBox.Show("An error occured . Check your internet connection.");
            }
            finally
            {

            }
            return success;
        }

        public async Task<dynamic> Fetch_categories()
        {
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
            catch (HttpRequestException ex) { 
                MessageBox.Show("An error occured . Check your internet connection.");
            }
            finally
            {

            }
            return null;
        }
    }
}
