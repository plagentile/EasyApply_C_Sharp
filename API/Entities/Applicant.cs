using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Applicant")]
    public class Applicant 
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public Resume ApplicantResume { get; set; }
       
        public string FirstName { get; set; }
       
        public string LastName { get; set; }

        public string City { get; set; }
        
        public string Country { get; set; }

        public string Gender { get; set; }

        public bool ApplicantHasDisability { get; set; }
        
        public bool ApplicantIsProtectedVeteran { get; set; }

        public bool ApplicantHasWorkAuthorization { get; set; }
    
    }
}