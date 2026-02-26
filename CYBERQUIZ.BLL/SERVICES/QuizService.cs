using CYBERQUIZ.BLL.DTOS;
using CYBERQUIZ.DAL.DATA;
using CYBERQUIZ.DAL.MODELS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CYBERQUIZ.BLL.SERVICES
{
    //Kommer sköta logiken för att hämta och visa quizen.
    public class QuizService : IQuizService
    {
        //dependency inj
        private readonly AppDbContext _db;

        //kort konstruktor
        public QuizService(AppDbContext db) => _db = db;

        //Hämtar alla frågor kopplad till en subkategori där ID matchar med subCategoryId, och hämtar även varje AnswerOption per fråga och omvandlar dessa till listor.
        //Notera att svarsalternativen är egna listor av en Question objekt i ännu en lista :)
        public async Task<List<QuestionDto>> GetQuestionsForSubCategoryAsync(int subCategoryId)
        {
            return await _db.Questions
            .Where(q => q.SubCategoryId == subCategoryId)
            .Select(q => new QuestionDto
            {
                Id = q.Id,
                Text = q.Text,
                AnswerOptions = q.AnswerOptions.Select(a => new AnswerOptionDto
                {
                    Id = a.Id,
                    Text = a.Text
                }).ToList()
            }).ToListAsync();
        }


        public async Task<bool> SubmitAnswerAsync(SubmitAnswerDto dto)
        {
            //kanske behöver validera om svaret också kan sammankopplas med frågan? Vi får se.

            //Hämtar det valda AnswerOption för att kontrollera om det är korrekt
            var answer = await _db.AnswerOptions.FindAsync(dto.SelectedAnswerOptionId);
            
            if (answer == null) return false;

            //Skapar ett nytt UserResult och lägger till det i DbContext
            _db.UserResults.Add(new UserResult
            {
                UserId = dto.UserId,
                SessionId = dto.SessionId, // <-- ny
                QuestionId = dto.QuestionId,
                SelectedAnswerOptionId = dto.SelectedAnswerOptionId,
                IsCorrect = answer.IsCorrect,
                AnsweredAt = DateTime.UtcNow
            });

            await _db.SaveChangesAsync(); //Sparar svaret i db
            //returnerar boolean på om svaret var korrekt eller ej
            return answer.IsCorrect;
        }
    }
}
