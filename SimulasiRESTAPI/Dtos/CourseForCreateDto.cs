using System.ComponentModel.DataAnnotations;

namespace SimulasiRESTAPI.Dtos
{
    public class CourseForCreateDto
    {
        [Required]
        public int AuthorID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(1500)]
        public string Description { get; set; }
    }
}
