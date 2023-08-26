using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace KAMM_FARM_SERVICES.DAL
{
    public class FarmersDAL
    {
        HttpClient client = new HttpClient();

        public async Task<dynamic> Fetch(string village , string status_type = null)
        {
            try
            {
                //var watch = System.Diagnostics.Stopwatch.StartNew();
                // the code that you want to measure comes here
                //Posting to online server
                string derived_uri ;
                if (status_type != null)
                {

                    derived_uri = Env.live_url + "/Village_farmers/" + village + "?status_type=" + status_type;


                }else
                {
                    derived_uri = Env.live_url + "/Village_farmers/" + village;

                }

                // Wrap our JSON inside a StringContent which then can be used by the HttpClient class

                HttpResponseMessage response = await client.GetAsync(derived_uri);

                response.EnsureSuccessStatusCode();
                //watch.Stop();
                //var elapsedMs = watch.ElapsedMilliseconds;
                //MessageBox.Show(elapsedMs.ToString());
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
            catch(Exception ex)
            {
                MessageBox.Show("Check your internet connection.");

            }
            finally
            {

            }
            return null;
        }

        public async Task<dynamic> change_status(string id  , bool status)
        {
            try
            {
                //Posting to online server
                string derived_uri = Env.live_url + "/ChangeStatus/";
                var stringPayload = JsonConvert.SerializeObject(new { id, status });

                // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
                var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync(derived_uri , httpContent);

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
            catch(Exception ex)
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
