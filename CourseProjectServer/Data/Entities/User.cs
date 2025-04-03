using System.ComponentModel.DataAnnotations;

namespace CourseProjectServer.Data.Entities {
    public interface User {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}
