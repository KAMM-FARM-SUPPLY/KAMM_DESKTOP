using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace KAMM_FARM_SERVICES.DAL
{
    public class LoanApplicationsDAL
    {
        HttpClient client = new HttpClient();

        public async Task<dynamic> FetchFarmerLoans(int farmer_id)
        {
            try
            {
                //Posting to online server
                string derived_uri = Env.live_url + "/Getapplications/?farmer_id="+farmer_id;
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
