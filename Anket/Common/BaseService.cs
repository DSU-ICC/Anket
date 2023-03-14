using BasePersonDBService.Interfaces;
using BasePersonDBService.Services;
using DomainService.Repository;
using DomainService.Repository.Interface;
using DSUContextDBService.Interfaces;
using DSUContextDBService.Services;

namespace Anket.Common
{
    public static class BaseService
    {
        public static void AddDBService(this IServiceCollection services)
        {
            services.AddScoped<IDSUActiveData, DSUActiveData>();
            services.AddScoped<IBasePersonActiveData, BasePersonActiveData>();

            #region Repositories
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IResultRepository, ResultRepository>();
            services.AddScoped<ITestingTeacherRepository, TestingTeacherRepository>();
            #endregion
        }
    }
}
