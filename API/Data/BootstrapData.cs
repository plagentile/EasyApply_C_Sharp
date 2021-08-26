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




            //Build applicants
            for(int x = 0 ; x < 10; x++)
            {
                Applicant applicant = new Applicant();
                applicant.ApplicantResume = new Resume();

                applicant.UserName = "UserName_" + x;
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