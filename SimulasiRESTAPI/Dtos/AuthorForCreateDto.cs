using SimulasiRESTAPI.ValidationAttributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace SimulasiRESTAPI.Dtos
{
    [AuthorFirstLastMustBeDifferentAttribute]
    public class AuthorForCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [MaxLength(50)]
        public string MainCategory { get; set; }
    }
}
