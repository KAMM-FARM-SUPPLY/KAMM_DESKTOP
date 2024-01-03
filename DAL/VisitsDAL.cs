using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAMM_FARM_SERVICES.DAL
{
    public class VisitsDAL
    {
        HttpClient client = new HttpClient();



        public async Task<dynamic> Fetch_Visits()
        {
            try
            {
                //Posting to online server
                string derived_uri = Env.live_url + "/GetVisits";
                //var stringPayload = JsonConvert.SerializeObject(productprop);

                // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
                //var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

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

    }
}
