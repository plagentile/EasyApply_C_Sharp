using System.Collections.Generic;

namespace API.DTOs
{
    public class CorporateDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string KnownAs { get; set; }
        public string BackgroundPhotoURL { get; set; }
        public ICollection<JobPostingDto> Openings { get; set; }
    }
}