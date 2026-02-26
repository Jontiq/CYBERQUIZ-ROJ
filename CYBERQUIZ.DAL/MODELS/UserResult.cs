using System;
using System.Collections.Generic;
using System.Text;

namespace CYBERQUIZ.DAL.MODELS
{
    public class UserResult
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int QuestionId { get; set; }
        public Question Question { get; set; } = null!;
        public int SelectedAnswerOptionId { get; set; }
        public bool IsCorrect { get; set; }
        public DateTime AnsweredAt { get; set; } = DateTime.UtcNow;
        public Guid SessionId { get; set; } //Ska skapa ett id för varje quizz, möjligör för användaren att endast se sitt absolut bästa resultat
    }
}
