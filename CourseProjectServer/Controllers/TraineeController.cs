using CourseProjectServer.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseProjectServer.Controllers {
    public class TraineeController : Controller {
        private readonly ILogger<TraineeController> _logger;
        IList<Trainee> Trainees { get; set; } = new List<Trainee>() {
            new Trainee(1, "Amga", "B", "aboba@mail.ru", 2, null, null),
            new Trainee(2, "Andrey", "D", "adnrey@mail.ru", 1, null, null)
        }; //потом dbcontext

        public TraineeController (ILogger<TraineeController> logger) {
            _logger = logger;
        }
        internal IEnumerable<Trainee> GetAll () {
            _logger.LogInformation("trainee get all"); //можно добавить юзер чтобы и тренеров, и учеников
            //потом поиск из dbcontext
            return Trainees;
        }
    }
}
