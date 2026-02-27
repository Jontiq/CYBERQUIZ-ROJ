using System;
using System.Collections.Generic;
using System.Text;

namespace CYBERQUIZ.BLL.DTOS
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public List<AnswerOptionDto> AnswerOptions { get; set; } = new();
    }

    public class AnswerOptionDto
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
    }


}
