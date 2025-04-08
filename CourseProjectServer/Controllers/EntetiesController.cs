using CourseProjectServer.Data.Context;
using CourseProjectServer.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseProjectServer.Controllers { //потом добавить проверку по jwt токену, а потм и на posgtresql
    public class EntetiesController : Controller {
        private readonly ILogger<EntetiesController> _logger;
        private CourseDbContext dbContext;

        public EntetiesController (ILogger<EntetiesController> logger, CourseDbContext dbContext) {
            _logger = logger;
            this.dbContext = dbContext;
        }


        //дописать Exercise, ExerciseRaw
        #region Get
        internal async Task<IEnumerable<Trainee>> GetAllTrainees () {
            _logger.LogInformation("trainee get all");
            
            return await dbContext.Trainees.ToArrayAsync();
        }

        internal async Task<IEnumerable<Trainer>> GetAllTrainers () {
            _logger.LogInformation("trainer get all");

            return await dbContext.Trainers.ToArrayAsync();
        }

        internal async Task<IEnumerable<Workout>> GetAllWorkouts () {
            _logger.LogInformation("workout get all");

            return await dbContext.Workouts.ToArrayAsync();
        }

        internal async Task<Trainee> GetTrainee (int id) {
            _logger.LogInformation($"trainee get {id}");

            return await dbContext.Trainees.Where(t => t.Id == id).FirstOrDefaultAsync();
        }

        internal async Task<Trainer> GetTrainer (int id) {
            _logger.LogInformation($"trainer get {id}");

            return await dbContext.Trainers.Where(t => t.Id == id).FirstOrDefaultAsync();
        }

        internal async Task<Workout> GetWorkout (int id) {
            _logger.LogInformation($"workout get {id}");

            return await dbContext.Workouts.Where(t => t.Id == id).FirstOrDefaultAsync();
        }

        #endregion

        //потом добавить логгер везде
        #region Post
        internal async Task<IResult> AddTrainee (Trainee trainee) {
            await dbContext.Trainees.AddAsync(trainee);
            await dbContext.SaveChangesAsync();
            return TypedResults.Ok( trainee );
        }

        internal async Task<IResult> AddTrainer (Trainer trainer) {
            await dbContext.Trainers.AddAsync(trainer);
            await dbContext.SaveChangesAsync();
            return TypedResults.Ok( trainer );
        }

        internal async Task<IResult> AddWorkout (Workout workout) {
            await dbContext.Workouts.AddAsync(workout);
            await dbContext.SaveChangesAsync();
            return TypedResults.Ok( workout );
        }
        #endregion


        #region Delete
        internal async Task<IResult> DeleteTrainee (int id) {
            Trainee? trainee = await dbContext.Trainees
                .FirstOrDefaultAsync();
            if (trainee is null) return TypedResults.NotFound($"Trainee с ID = {id} не найден");
            return TypedResults.Ok( dbContext.Trainees.Remove(trainee) );
        }

        internal async Task<IResult> DeleteTrainer (int id) {
            Trainer? trainer = await dbContext.Trainers
                .FirstOrDefaultAsync();
            if (trainer is null) return TypedResults.NotFound($"Trainer с ID = {id} не найден");
            return TypedResults.Ok( dbContext.Trainers.Remove(trainer) );
        }

        internal async Task<IResult> DeleteWorkout (int id) {
            Workout? workout = await dbContext.Workouts
                .FirstOrDefaultAsync();
            if (workout is null) return TypedResults.NotFound($"Workout с ID = {id} не найден");
            return TypedResults.Ok (dbContext.Workouts.Remove(workout) );
        }
        #endregion


        #region Update
        internal async Task<IResult> UpdateTrainee (int id) {
            Trainee? trainee = await dbContext.Trainees
                .FirstOrDefaultAsync();
            if (trainee is null) return TypedResults.NotFound($"Trainee с ID = {id} не найден");
            return TypedResults.Ok( dbContext.Trainees.Update(trainee) );
        }
        #endregion
    }
}
