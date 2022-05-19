using System.ComponentModel.DataAnnotations;

namespace ComplexDataModel.Data.Entities;
    public class Office
    {
        [Key]
        public int InstructorId { get; set; }

        public string Room { get; set; }

        public string Building { get; set; }

        public Instructor Instructor { get; set; }
    }
