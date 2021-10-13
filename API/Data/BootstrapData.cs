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
                users.UserName = "a_username_" + x;
                users.Email = users.UserName + "@service.com";
                users.PhoneNumber = "000-000-0000"; //fix later
                //Add in role

                dataContext.Users.Add(users);               
            }

            for(int x = 0; x < 10; x++)
            {
                Users users = new Users();
                users.UserName = "c_username_" + x;
                
                //Add in role

                dataContext.Users.Add(users);               
            }     

            //Build applicants
            for(int x = 0 ; x < 10; x++)
            {
                Applicant applicant = new Applicant();
                applicant.ApplicantResume = new Resume();

                applicant.UserName = "a_username_" + x;
                applicant.FirstName = "a_firstName_" + x;
                applicant.LastName = "a_lastName_" + x;
                applicant.City = "City_" + x;
                applicant.Country = "Country_" + x;
                applicant.Gender = "Option";
                
                applicant.ApplicantHasDisability = false;
                applicant.ApplicantHasWorkAuthorization = true;
                applicant.ApplicantIsProtectedVeteran = false;

                dataContext.Applicants.Add(applicant);
            }


            //Build Corporations
            for(int x = 0 ; x < 10; x++)
            {
                Corporation corporation = new Corporation();
                corporation.Id = x;
                corporation.UserName = "c_username_" + x;
                corporation.KnownAs = "c_KnownAs_" + x;
                corporation.BackgroundPhotoURL = "";
                
                JobPosting jobPosting = new JobPosting();
                jobPosting.Id = x *10;
                jobPosting.PublicId = "Example-Public-Id";
                jobPosting.Title = "Example-Job-Title";
                jobPosting.Description = "Example Job Description";
                jobPosting.Location = "Example Job Location";
                jobPosting.PostedDate = "Add DateTime.toString";
                jobPosting.Corporation = corporation;
                jobPosting.CorporationId  = corporation.Id;
                      
                dataContext.JobPostings.Add(jobPosting);
                dataContext.Corporations.Add(corporation);

            }

            await dataContext.SaveChangesAsync();
        }
    }
}