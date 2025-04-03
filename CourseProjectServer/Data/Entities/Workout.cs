using System.ComponentModel.DataAnnotations;

namespace CourseProjectServer.Data.Entities {
    public class Workout {
        [Key] public int Id { get; set; }
        [Required] public IList<Exercise> Exercises { get; } = new List<Exercise>();
        [Required] public Trainee Trainee { get; set; }
        //привязка к тренеру через ученика

        public Workout (int id, IList<Exercise> exercises, Trainee trainee) {
            Id = id;
            Exercises = exercises;
            Trainee = trainee;
        }

        public Workout () {
        }
    }
}
