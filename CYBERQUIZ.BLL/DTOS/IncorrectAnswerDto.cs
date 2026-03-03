using System;
using System.Collections.Generic;
using System.Text;

namespace CYBERQUIZ.BLL.DTOS
{
    public class IncorrectAnswerDto
    {
        public string QuestionText { get; set; } = string.Empty;
        public string AiRecommendation { get; set; } = string.Empty;
    }
}
