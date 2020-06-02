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
        public string adminKey = "organizeradmin", userKey = "organizer";

        #region Dummy

        private string UserRole(string name, string password)
        {

            if (name == "admin" && password == "admin")
            {
                return adminKey;
            }
            else if (name == "orge" && password == "orge")
            {
                return userKey;
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
        
        public async Task<string> UserAuthorized(organizerlogin loginDetails)
        {
            ObjectHandlerJSON obj = new ObjectHandlerJSON();

            try
            {
                // Checks if user is admin first
                loginDetails.permission = "organizeradmin";
                string role = await obj.GetLoginRoleAPI(loginDetails);

                // If user is no admin, but can be a user
                if (role == null)
                {
                    loginDetails.permission = "organizer";
                    role = await obj.GetLoginRoleAPI(loginDetails);
                }

                // If all goes well
                return role;
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
    }
}