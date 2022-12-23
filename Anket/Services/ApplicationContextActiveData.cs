using Anket.DBService;
using Anket.Models;
using Microsoft.EntityFrameworkCore;

namespace Anket.Services
{
    public class ApplicationContextActiveData
    {
        private readonly ApplicationContext _applicationContext;
        public ApplicationContextActiveData(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IQueryable<Anketa> GetAnketa()
        {
            return _applicationContext.Anketas.Where(x => x.IsDeleted == false);
        }

        public Anketa GetAnketaById(int id)
        {
            return _applicationContext.Anketas.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Question> GetQuestions()
        {
            return _applicationContext.Questions.Where(x => x.IsDeleted == false);
        }

        public Question GetQuestionById(int id)
        {
            return _applicationContext.Questions.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Answer> GetAnswers()
        {
            return _applicationContext.Answers.Where(x => x.IsDeleted == false);
        }

        public Answer GetAnswerById(int id)
        {
            return _applicationContext.Answers.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Result> GetResults()
        {
            return _applicationContext.Results.Where(x => x.IsDeleted == false);
        }

        public Result GetResultById(int id)
        {
            return _applicationContext.Results.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<TestingTeacher> GetTestingTeachers()
        {
            return _applicationContext.TestingTeachers.Where(x => x.IsDeleted == false);
        }

        public TestingTeacher GetTestingTeacherById(int id)
        {
            return _applicationContext.TestingTeachers.FirstOrDefault(x => x.Id == id);
        }
    }
}
