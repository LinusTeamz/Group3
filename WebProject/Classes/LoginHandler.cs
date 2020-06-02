using System;
using System.Collections.Generic;
using System.Linq;
using WebProject.Models;
using System.Threading.Tasks;

namespace WebProject.classes
{
    public class LoginHandler
    {
        // Roles
        public string adminKey = "organizeradmin", userKey = "organizer";
        
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

                    // If API returns null for normal user, it will use our database to check if user exists. 
                    if(role == null)
                    {
                        List<Organizer> organizers = await obj.GetOrganizerList();

                        foreach (var item in organizers)
                        {
                            if(item.Name == loginDetails.username)
                            {
                                role = userKey;
                            }
                        }
                    }
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