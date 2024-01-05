using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAMM_FARM_SERVICES.Helpers
{
    public static class Handlers
    {
        static HttpClient client = new HttpClient();

        public static async Task<dynamic> Fetch(string derived_uri)
        {
            try
            {
                
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
            catch (HttpRequestException ex)
            {
                MessageBox.Show("An error occured . Check your internet connection.");
            }
            finally
            {

            }
            return null;
        }


        public static async Task<bool> Post(string derived_uri , object data)
        {
            bool success = false;
            try
            {
                //Posting to online server
                var stringPayload = JsonConvert.SerializeObject(data);

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
            catch (HttpRequestException ex)
            {
                MessageBox.Show("An error occured . Check your internet connection.");
            }
            finally
            {

            }
            return success;

        }



        public static async Task<bool> Delete(string derived_uri)
        {
            bool success = false;
            try
            {
                //Posting to online server

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
            catch (HttpRequestException ex)
            {
                MessageBox.Show("An error occured . Check your internet connection.");
            }
            finally
            {

            }
            return success;
        }



        public static async Task<bool> Update(string derived_uri , object data)
        {
            bool success = false;
            try
            {
                //Posting to online server
                var stringPayload = JsonConvert.SerializeObject(data);

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
            catch (HttpRequestException ex)
            {
                MessageBox.Show("An error occured . Check your internet connection.");
            }
            finally
            {

            }
            return success;
        }


    }
}
