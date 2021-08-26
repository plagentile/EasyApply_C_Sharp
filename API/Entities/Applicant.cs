using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Applicants")]
    public class Applicant
    {

        public enum ApplicantGender{
            Undisclosed,
            Male,
            Female,
            Other
        }

        public Resume ApplicantResume { get; set; }
        public string UserName { get; set; }

        public string FirstName { get; set; }
       
        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string City { get; set; }
        
        public string Country { get; set; }

        public int Id { get; set; }

        public ApplicantGender Gender { get; set; }

        public bool ApplicantHasDisability { get; set; }
        
        public bool ApplicantIsProtectedVeteran { get; set; }

        public bool ApplicantHasWorkAuthorization { get; set; }
    
    }
}