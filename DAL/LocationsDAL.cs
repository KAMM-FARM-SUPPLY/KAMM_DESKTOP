using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAMM_FARM_SERVICES.DAL
{
    public class LocationsDAL
    {
        HttpClient client = new HttpClient();


        public async Task<dynamic> Fetch()
        {
            try
            {
                //Posting to online server
                string derived_uri = Env.live_url + "/Locations/";
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
            finally {

            }
            return null;
        }

        public async Task<dynamic> Fetch_districts()
        {
            try
            {
                //Posting to online server
                string derived_uri = Env.live_url + "/Districts/";
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

        public async Task<dynamic> Fetch_subcounties(int district_id = 0)
        {
            try
            {
                //Posting to online server
                
                string derived_uri = Env.live_url + "/Subcounty/";

                if (district_id != 0)
                {
                    derived_uri = Env.live_url + "/Subcounty?district_id=" + district_id ;
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

        public async Task<dynamic> Fetch_villages(int subcounty_id = 0)
        {
            try
            {
                //Posting to online server
                string derived_uri = Env.live_url + "/Villages";

                if (subcounty_id != 0)
                {
                    derived_uri = Env.live_url + "/Villages?County_id=" + subcounty_id;
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


        public async Task<bool> Create_District(string name , string more_info = null)
        {
            bool success = false;
            try
            {
                //Posting to online server
                string derived_uri = Env.live_url + "/Create_district/";
                var stringPayload = JsonConvert.SerializeObject(new {name , more_info});

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


        //Creating a subcounty
        public async Task<bool> Create_SubCounty(string name, int district_id, string more_info = null)
        {
            bool success = false;
            try
            {
                //Posting to online server
                string derived_uri = Env.live_url + "/Create_SubCounty/" + district_id + "/";
                var stringPayload = JsonConvert.SerializeObject(new { name, more_info });

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

        //Creating a village
        public async Task<bool> Create_Village(string name, int county_id, string more_info = null)
        {
            bool success = false;
            try
            {
                //Posting to online server
                string derived_uri = Env.live_url + "/Create_village/" + county_id + "/";
                var stringPayload = JsonConvert.SerializeObject(new { name, more_info });

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




        //Updating district
        public async Task<bool> Update_District(string name, int district_id , string more_info)
        {
            bool success = false;
            try
            {
                //Posting to online server
                string derived_uri = Env.live_url + "/Update_district/" + district_id + "/";
                var stringPayload = JsonConvert.SerializeObject(new { name, more_info });

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

        //Updating County
        public async Task<bool> Update_County(string name, int county_id, string more_info)
        {
            bool success = false;
            try
            {
                //Posting to online server
                string derived_uri = Env.live_url + "/Update_SubCounty/" + county_id + "/";
                var stringPayload = JsonConvert.SerializeObject(new { name, more_info });

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

        //Updating Village
        public async Task<bool> Update_Village(string name, int village_id, string more_info)
        {
            bool success = false;
            try
            {
                //Posting to online server
                string derived_uri = Env.live_url + "/Update_village/" + village_id + "/";
                var stringPayload = JsonConvert.SerializeObject(new { name, more_info });

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


        //Deleting a district
        public async Task<bool> Delete_District(int district_id)
        {
            bool success = false;
            try
            {
                //Posting to online server
                string derived_uri = Env.live_url + "/Delete_district/" + district_id + "/";

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

        //Deleting a subcounty
        public async Task<bool> Delete_Subcounty(int county_id)
        {
            bool success = false;
            try
            {
                //Posting to online server
                string derived_uri = Env.live_url + "/Delete_county/" + county_id + "/";

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

        //Deleting a village
        public async Task<bool> Delete_Village(int village_id)
        {
            bool success = false;
            try
            {
                //Posting to online server
                string derived_uri = Env.live_url + "/Delete_village/" + village_id + "/";

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




    }
}
