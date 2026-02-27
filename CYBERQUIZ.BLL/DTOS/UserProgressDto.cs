using System;
using System.Collections.Generic;
using System.Text;

namespace CYBERQUIZ.BLL.DTOS
{
    public class UserProgressDto
    {
        public int TotalQuestions { get; set; }
        public int AnsweredCorrectly { get; set; }
        public double OverallPercent => TotalQuestions == 0 ? 0 : (double)AnsweredCorrectly / TotalQuestions * 100;
        public List<SubCategoryProgressDto> SubCategoryProgress { get; set; } = new();
    }

    public class SubCategoryProgressDto
    {
        public string SubCategoryName { get; set; } = string.Empty;
        public int Correct { get; set; }
        public int Total { get; set; }
        public double Percent => Total == 0 ? 0 : (double)Correct / Total * 100;
        public bool Passed => Percent >= 80;
    }
}
