using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("JobPostings")]
    public class JobPosting
    { 
        public int Id { get; set; }
        public string PublicId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime PostedDate { get; set; }
        public Corporation Corporation { get; set; }
        public int CorporationId { get; set; }
    }
}