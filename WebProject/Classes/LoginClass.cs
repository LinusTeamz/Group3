using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI.WebControls;

namespace WebProject.classes
{
    public class LoginClass
    {
        /// <summary>
        /// Name and password sets the userrole when called
        /// </summary>

        #region Dummy
    
        private string UserRole(string name, string password)
        {

            if (name == "admin" && password == "admin")
            {
                return "admin";
            }
            else if (name == "orge" && password == "orge")
            {
                return "normal";
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Admin has CRUD. Normal has CRUD without the CUD
        /// </summary>
        public string GetUser(string name, string password)
        {
            string role = UserRole(name, password);

            return role;
        }
        #endregion

        //public async System.Threading.Tasks.Task<string> LoginDetailsAsync()
        //{
        //TODO: Logik för login

        //    string role = null;

        //    try
        //    {
        //        role = await CallAPIAsync();

        //        if (role == "normal")
        //        {
        //            return "normal";
        //        }
        //        else if (role.Equals("admin"))
        //        {
        //            return "admin";
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }

        //    catch (Exception e)
        //    {
        //        return e.Message.ToString();
        //    }
        //}

        //private async System.Threading.Tasks.Task<string> CallAPIAsync()
        //{
        //    string result;
        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            Passing service base url
        //            client.BaseAddress = new Uri(BaseURL);

        //            client.DefaultRequestHeaders.Clear();
        //            Define request data format
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //            Sending request to find web api REST service resource GetAllEmployees using HttpClient

        //            HttpResponseMessage Res = await client.GetAsync();

        //            Checking the response is successful or not which is sent using HttpClient
        //            if (Res.IsSuccessStatusCode)
        //            {
        //                Storing the response details recieved from web api
        //                var EmpResponse = Res.Content.ReadAsStringAsync().Result;

        //                Deserializing the response recieved from web api and storing into the Employee list
        //                FacilityInfo = JsonConvert.DeserializeObject<List<Facility>>(EmpResponse);

        //            }

        //            return null;
        //        }
        //    }
        //    catch
        //    {
        //        return true;
        //    }
        //}
    }
}