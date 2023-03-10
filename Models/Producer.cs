using System.ComponentModel.DataAnnotations;

namespace ASPecommerce.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        public string ProfilePicture { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
