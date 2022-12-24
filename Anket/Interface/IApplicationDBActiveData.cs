using Anket.DBService;
using Anket.Models;

namespace Anket.Interface
{
    public interface IApplicationDBActiveData
    {
        public IQueryable<Anketa> GetAnketa();
        public Anketa GetAnketaById(int id);
        public IQueryable<Question> GetQuestions();
        public Question GetQuestionById(int id);
        public IQueryable<Answer> GetAnswers();
        public Answer GetAnswerById(int id);
        public IQueryable<Result> GetResults();
        public Result GetResultById(int id);
        public IQueryable<TestingTeacher> GetTestingTeachers();
        public TestingTeacher GetTestingTeacherById(int id);
    }
}
