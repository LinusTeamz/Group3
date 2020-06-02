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
        public string adminRole = "organizeradmin", userRole = "organizer";
        
        public async Task<organizerlogin> UserAuthorized(organizerlogin loginDetails)
        {
            ObjectHandlerJSON obj = new ObjectHandlerJSON();
            organizerlogin details = new organizerlogin();

            try
            {
                // Checks if user is admin first
                loginDetails.permission = adminRole;
                string role = await obj.GetLoginRoleAPI(loginDetails);

                // If admin
                details.permission = role;

                // If user is no admin, but can be a user
                if (role == null)
                {
                    // If API returns null for normal user, it will use our database to check if user exists.       
                    List<Organizer> organizers = await obj.GetOrganizerList();

                    foreach (var item in organizers)
                    {
                        if(item.Name == loginDetails.username)
                        {
                            details.username = item.Name;
                            details.Id = item.Id;
                            details.permission = userRole;
                        }
                    }
                }
                // If all goes well
                return details;
            }
            catch 
            {
                return null;
            }
        }
    }
}