using System.ComponentModel.DataAnnotations;

namespace Data.Layer.Models.Domain
{
    public class Person
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string email{ get; set; }

        [Required]
        public string address { get; set; }
    }
}
