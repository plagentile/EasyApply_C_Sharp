using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class BootstrapData
    {
        
        BootstrapData(){

        }

        public static async Task seedData(DataContext dataContext)
        {

            if(await dataContext.Users.AnyAsync()) return;

            //Build AppUsers
            for(int x = 0; x < 10; x++)
            {
                Users users = new Users();

                users.UserName = "username_" + x;
                users.Role = "Applicant";

                using var hmac = new HMACSHA512();
                users.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("!!Password"));
                users.PasswordSalt = hmac.Key;

                dataContext.Users.Add(users);               
            }    



            //Build applicants
            for(int x = 0 ; x < 10; x++)
            {
                Applicant applicant = new Applicant();
                applicant.ApplicantResume = new Resume();

                applicant.UserName = "username_" + x;
                applicant.FirstName = "FirstName_" + x;
                applicant.LastName = "LastName_" + x;
                applicant.Email = applicant.FirstName + "@service.com";
                applicant.PhoneNumber = "000-000-0000"; //fix later
                applicant.City = "City_" + x;
                applicant.Country = "Country_" + x;
                applicant.Gender = "Option";
                
                applicant.ApplicantHasDisability = false;
                applicant.ApplicantHasWorkAuthorization = true;
                applicant.ApplicantIsProtectedVeteran = false;

                dataContext.Applicants.Add(applicant);
            }

            await dataContext.SaveChangesAsync();
        }
    }
}