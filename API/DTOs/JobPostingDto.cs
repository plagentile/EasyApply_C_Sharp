using System;

namespace API.DTOs
{
    public class JobPostingDto
    {
        public string PublicId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string PostedDate { get; set; }
    }
}