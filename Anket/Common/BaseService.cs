using BasePersonDBService.Interfaces;
using BasePersonDBService.Services;
using DSUContextDBService.Interfaces;
using DSUContextDBService.Services;
using Infrastructure.Repository;
using Infrastructure.Repository.Interface;

namespace Anket.Common
{
    public static class BaseService
    {
        public static void AddServiceCollection(this IServiceCollection services)
        {
            services.AddScoped<IDSUActiveData, DSUActiveData>();
            services.AddScoped<IBasePersonActiveData, BasePersonActiveData>();
            services.AddSingleton<AuthOptions>();

            #region Repositories
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IResultRepository, ResultRepository>();
            services.AddScoped<ITestingTeacherRepository, TestingTeacherRepository>();
            services.AddScoped<IDsuRepository, DsuRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IOperationModeRepository, OperationModeRepository>();
            #endregion
        }
    }
}
