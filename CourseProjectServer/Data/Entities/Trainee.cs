using System.ComponentModel.DataAnnotations;

namespace CourseProjectServer.Data.Entities {
    public class Trainee : User {
        [Key] public int Id {  get; set; }
        [Required] public string Name {  get; set; }
        [Required] public string Surname {  get; set; }
        [Required] public string Email { get; set; }
        public int CountOfTrainsInWeek {  get; set; }
        [Required] public Trainer Trainer { get; set; }
        [Required] public IList<Workout> Workouts { get; } = new List<Workout>();

        public Trainee (int id, string name, string surname, string email, int countOfTrainsInWeek, Trainer uTrainer, IList<Workout> workouts) {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            CountOfTrainsInWeek = countOfTrainsInWeek;
            Trainer = uTrainer;
            Workouts = workouts;
        }

        public Trainee () {
        }
    }
}
