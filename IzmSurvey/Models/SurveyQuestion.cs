﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IzmSurvey.Models
{
    public class SurveyQuestion
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("SurveyId")]
        public CustomerSurvey? Survey { get; set; }

        public Guid SurveyId { get; set; }

        public string Question { get; set; } = string.Empty;

        public string Answer { get; set; } = string.Empty;

        public string PossibleAnswers { get; set; }

        public SurveyQuestion(Guid surveyId, Guid id, string question, string possibleAnswers = "")
        {
            SurveyId = surveyId;
            Id = id;
            Question = question;
            PossibleAnswers = possibleAnswers;
        }
    }
}


