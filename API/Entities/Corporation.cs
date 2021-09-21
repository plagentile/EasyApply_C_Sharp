using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Corporation")]
    public class Corporation
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string KnownAs { get; set; }
        public string BackgroundPhotoURL { get; set; }
        public ICollection<JobPosting> Openings { get; set; }

    }
}