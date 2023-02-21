using Anket.Repository.Interface;
using BasePersonDBService.Interfaces;
using DSUContextDBService.Interfaces;

namespace Anket.Common.Interface
{
    public interface IUnitOfWork
    {
        IAnswerRepository AnswerRepository { get; }
        IQuestionRepository QuestionRepository { get; }
        IResultRepository ResultRepository { get; }
        ITestingTeacherRepository TestingTeacherRepository { get; }
        IDSUActiveData DSUActiveData { get; }
        IBasePersonActiveData BasePersonActiveData { get; }
    }
}
