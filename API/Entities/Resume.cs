using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Resume")]
    public class Resume
    {
        public int Id { get; set; }

        public string URL { get; set; }
        
    }
}