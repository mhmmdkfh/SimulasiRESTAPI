using System.ComponentModel.DataAnnotations;

namespace SimulasiRESTAPI.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public int AuthorID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(1500)]
        public string Description { get; set; }

        public Author Author { get; set; }

    }
}
