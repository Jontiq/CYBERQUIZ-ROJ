using System;
using System.Collections.Generic;
using System.Text;

namespace CYBERQUIZ.DAL.MODELS
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; } = null!;
        public ICollection<AnswerOption> AnswerOptions { get; set; } = new List<AnswerOption>();
    }
}
