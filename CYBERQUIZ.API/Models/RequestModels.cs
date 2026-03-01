namespace CYBERQUIZ.API.Models
{
   
    // beskriver vad UI skickar i request-bodyn
    // De är INTE Identity-modeller – de är enkla "brevlådor"
    // Identity-modellerna används internt i controllers och services
    

    // Används av POST /api/auth/login
    public class LoginModel
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

// Används av POST /api/auth/register
public class RegisterModel
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}


// Används av POST /api/quiz/answer
// SessionId är ett Guid som UI genererar vid quizstart
// Det grupperar alla svar från samma quiz-session
// så att CategoryService kan hitta bästa session per användare
public class SubmitAnswerModel
{
    public Guid SessionId { get; set; }
    public int QuestionId { get; set; }
    public int SelectedAnswerOptionId { get; set; }
}

// PROFIL-MODELLER
// Används av PUT /api/profile/email
public class ChangeEmailModel
{
    public string NewEmail { get; set; } = string.Empty;
}
}