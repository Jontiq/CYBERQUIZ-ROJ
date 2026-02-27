using System;
using System.Collections.Generic;
using System.Text;

namespace CYBERQUIZ.BLL.DTOS
{
    public class SubmitAnswerDto
    {
        public string UserId { get; set; } = string.Empty;
        public Guid SessionId { get; set; } // <-- ny
        public int QuestionId { get; set; }
        public int SelectedAnswerOptionId { get; set; }
    }
}
