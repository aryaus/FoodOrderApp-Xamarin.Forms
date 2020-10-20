using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using FoodOrderApp.Models;

namespace FoodOrderApp.Services
{
    public class UserService
    {
        FirebaseClient client;
        public UserService()
        {
            client = new FirebaseClient("https://foodorderapp-60d9b.firebaseio.com/");
        }

        //This method verifies the existance of user
        public async Task<bool> IsUserExists(string uname)
        {
            var user = (await client.Child("Users")
                .OnceAsync<User>()).Where(u => u.Object.Username == uname).FirstOrDefault();
            return (user != null);
        }
        // This method is to verify the input for registration
        public async Task<bool> RegisterUser(string uname, string passwd)
        {
           if (await IsUserExists(uname) == false)
            {
                await client.Child("Users")
                    .PostAsync(new User()
                    {
                      Username = uname ,
                      Password = passwd
                        
                    });
                return true;
            } else
            {
                return false;
            }
        }

        // this method support the login 
        public async Task<bool> LoginUser(string uname, string passwd)
        {
            var user = (await client.Child("Users")
               .OnceAsync<User>()).Where(u => u.Object.Username == uname)
               .Where(u => u.Object.Password == passwd).FirstOrDefault();
            return (user != null);

        }
    }
}
