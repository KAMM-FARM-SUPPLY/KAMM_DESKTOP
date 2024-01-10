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

        public async Task<dynamic> FetchFarmerLoans(int farmer_id , bool lazy_load = true)
        {
            try
            {
                //Posting to online server
                string derived_uri = Env.live_url + "/Getapplications/?lazy_load=" + lazy_load.ToString();

                if (farmer_id != 0)
                {
                    derived_uri = Env.live_url + "/Getapplications/?farmer_id=" + farmer_id;
                }
                
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


        public async Task<dynamic> QueryFarmerLoans(
            bool lazy_load = true ,
            int farmer_id=0,
            string Status="",
            string District="",
            string Subcounty="",
            string Village="",
            string Start_date="",
            string End_date="",
            string amount_symbol="",
            string amount="",
            string balance_symbol="",
            string balance="",
            bool page_action = false,
            int page = 0
            )
        {
            try
            {
                //Posting to online server
                string derived_uri = Env.live_url + "/Queryapplications?" +
                    ((!lazy_load) ? ("lazy_load=False&") : ("")) +
                    ((farmer_id != 0)?("Farmer=" + farmer_id.ToString() + "&") :("")) +
                    ((Status != "")?("Status=" + Status + "&"):("")) + 
                    ((District != "")?("District=" + District + "&"):("")) +
                    ((Subcounty != "")?("Subcounty=" + Subcounty + "&"):(""))+
                    ((Village != "")?("Village=" + Village + "&"):(""))+
                    ((Start_date != "")?("Start_date=" + Start_date + "&"):("")) +
                    ((End_date != "")?("End_date=" + End_date + "&") :("")) +
                    ((amount_symbol != "") ? ("amount_symbol=" + amount_symbol + "&") : ("")) +
                    ((amount != "") ? ("amount=" + amount + "&") : ("")) +
                    ((balance_symbol != "") ? ("balance_symbol=" + balance_symbol + "&") : ("")) +
                    ((balance != "") ? ("balance=" + balance + "&") : ("")) +
                    ((page_action && (page != 0)) ? ("page=" + page + "&") : ("")) 

                    ;

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
