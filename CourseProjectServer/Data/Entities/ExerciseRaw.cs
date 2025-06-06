﻿using System.ComponentModel.DataAnnotations;

namespace CourseProjectServer.Data.Entities {
    public class ExerciseRaw {
        [Key] public int Id { get; set; }//добавить потом сюда группу мышц
        [Required] public string Name { get; set; }
        [Required] public string ExerciseUrl { get; set; }

        public ExerciseRaw (int id, string name, string exerciseUrl) {
            Id = id;
            Name = name;
            ExerciseUrl = exerciseUrl;
        }

        public ExerciseRaw () {
        }
    }
}
