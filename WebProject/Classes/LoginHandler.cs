using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI.WebControls;
using WebProject.Models;
using System.Threading.Tasks;

namespace WebProject.classes
{
    public class LoginHandler
    {
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

        public string GetUser(string name, string password)
        {
            string role = UserRole(name, password);

            return role;
        }
        #endregion
        
        public async Task <string> UserDetails(string email, string password)
        {
            List<loginModelAPI> loginList = new List<loginModelAPI>();
            ObjectHandlerJSON obj = new ObjectHandlerJSON();

            // Null by default
            string role = null;

       

            loginList = await obj.GetLoginList();
            
            // If email and password is true

            bool apiPasswordExist = loginList.Any(m => m.Email.Equals(email) && m.Password.Equals(password));

            // Will only loop if item exists
            if (apiPasswordExist)
            {
                // Not efficient to loop, but works...
                foreach (var item in loginList)
                {
                    // If both are true the role will be set
                    if (item.Password.Equals(password) && item.Email.Equals(email))
                    {
                        role = item.Role;
                    }
                }
            }
            return role;
        }
    }
}