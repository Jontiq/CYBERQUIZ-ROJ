using System;
using System.Collections.Generic;
using System.Text;

namespace CYBERQUIZ.DAL.MODELS
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
