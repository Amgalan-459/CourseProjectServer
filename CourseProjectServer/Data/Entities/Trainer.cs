using System.ComponentModel.DataAnnotations;

namespace CourseProjectServer.Data.Entities {
    public class Trainer : User {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Surname { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Password { get; set; }
        [Required] public IList<Trainee> Trainees { get;}  = new List<Trainee>();

        public Trainer (int id, string name, string surname, string email, string password, IList<Trainee> trainees) {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            Trainees = trainees;
        }

        public Trainer () {
        }
    }
}
