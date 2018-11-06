using System.ComponentModel.DataAnnotations;

namespace ApiGateway
{
    public class Course
    {
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Range(0, 1000)]
        public int Length { get; set; }
    }
}