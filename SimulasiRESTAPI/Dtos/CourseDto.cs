using System.ComponentModel.DataAnnotations;

namespace SimulasiRESTAPI.Dtos
{
    public class CourseDto
    {
        public int Id { get; set; }
        public int AuthorID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
