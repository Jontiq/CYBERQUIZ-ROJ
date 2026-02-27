using System;
using System.Collections.Generic;
using System.Text;

namespace CYBERQUIZ.BLL.DTOS
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<SubCategoryDto> SubCategories { get; set; } = new();
    }
}
