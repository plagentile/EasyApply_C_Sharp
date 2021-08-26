using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Corporation")]
    public class Corporation
    {
        public int Id { get; set; }
        public string UserName { get; set; }
          
    }
}