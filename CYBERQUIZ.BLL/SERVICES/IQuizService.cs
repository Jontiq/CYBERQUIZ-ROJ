using CYBERQUIZ.BLL.DTOS;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CYBERQUIZ.BLL.SERVICES
{
    public interface IQuizService
    {

        //// För att ladda sidan med alla 10 frågor per subCategory
        Task<List<QuestionDto>> GetQuestionsForSubCategoryAsync(int subCategoryId);

        //// För när man trycker på "Submit" längst ner
        //// Denna tar emot en lista på alla svar användaren valt
        Task<bool> SubmitAnswerAsync(SubmitAnswerDto dto);

    }
}
