using Anket.Interface;
using Anket.Models;
using Microsoft.AspNetCore.Builder;

namespace Anket.Services
{
    public static class BaseService
    {
        public static void AddDBService(this IServiceCollection services)
        {
            services.AddSingleton<IDsuActiveData, DsuActiveData>();

            services.AddScoped<IGenericRepository<Anketa>, ApplicationRepository<Anketa>>();
            services.AddScoped<IGenericRepository<Answer>, ApplicationRepository<Answer>>();
            services.AddScoped<IGenericRepository<Moderator>, ApplicationRepository<Moderator>>();
            services.AddScoped<IGenericRepository<Question>, ApplicationRepository<Question>>();
            services.AddScoped<IGenericRepository<TestingTeacher>, ApplicationRepository<TestingTeacher>>();
            services.AddScoped<IGenericRepository<Result>, ApplicationRepository<Result>>();


            services.AddScoped<IGenericRepository<PersFilial>, BasePersonRepository<PersFilial>>();
            services.AddScoped<IGenericRepository<PersDivision>, BasePersonRepository<PersDivision>>();
            services.AddScoped<IGenericRepository<PersDepartment>, BasePersonRepository<PersDepartment>>();
            services.AddScoped<IGenericRepository<Person>, BasePersonRepository<Person>>();

            services.AddScoped<IGenericRepository<CaseCEdue>, DsuBaseRepository<CaseCEdue>>();
            services.AddScoped<IGenericRepository<CaseCEdukind>, DsuBaseRepository<CaseCEdukind>>();
            services.AddScoped<IGenericRepository<CaseCPlat>, DsuBaseRepository<CaseCPlat>>();
            services.AddScoped<IGenericRepository<CaseCStatus>, DsuBaseRepository<CaseCStatus>>();

            services.AddScoped<IGenericRepository<CaseSDepartment>, DsuBaseRepository<CaseSDepartment>>();
            services.AddScoped<IGenericRepository<CaseSSpecialization>, DsuBaseRepository<CaseSSpecialization>>();
            services.AddScoped<IGenericRepository<CaseSStudent>, DsuBaseRepository<CaseSStudent>>();
            services.AddScoped<IGenericRepository<CaseSTeacher>, DsuBaseRepository<CaseSTeacher>>();
            services.AddScoped<IGenericRepository<CaseUkoExam>, DsuBaseRepository<CaseUkoExam>>();
            services.AddScoped<IGenericRepository<CaseUkoModule>, DsuBaseRepository<CaseUkoModule>>();
            services.AddScoped<IGenericRepository<CaseUkoZachet>, DsuBaseRepository<CaseUkoZachet>>();
        }
    }
}