using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    
        public class Student
        {
            public int studentId { get; set; }

        [Required]
            public string firstName { get; set; }
        [Required]
            public string lastName { get; set; }
        [Required]
            public int age { get; set; }
        [Required]
            public string grade { get; set; }
        }

    
}
