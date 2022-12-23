using Anket.Models;

namespace Anket.Interface
{
    public interface IApplicationDBActiveData
    {
        public List<Anketa> GetAnketas();
        public Anketa GetAnket(int id);
        public List<Question> GetQuestions();
        public Question GetQuestion(int id);
        public List<Answer> GetAnswers();
        public Answer GetAnswer(int id);
    }
}
