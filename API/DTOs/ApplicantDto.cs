namespace API.DTOs
{
    public class ApplicantDto
    {
        public ResumeDto ApplicantResume { get; set; }
       
        public string UserName { get; set; }

        public string FirstName { get; set; }
       
        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string City { get; set; }
        
        public string Country { get; set; }

        public string Gender { get; set; }

        public int Id { get; set; }

        public bool ApplicantHasDisability { get; set; }
        
        public bool ApplicantIsProtectedVeteran { get; set; }

        public bool ApplicantHasWorkAuthorization { get; set; } 
    }
}