using System;
using System.Collections.Generic;
using System.Text;

namespace CYBERQUIZ.BLL.DTOS
{
    public class SubCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int QuestionCount { get; set; }
        public bool IsUnlocked { get; set; }
        public double ProgressPercent { get; set; }
    }
}
