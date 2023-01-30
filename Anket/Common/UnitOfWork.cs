using Anket.Common.Interface;
using Anket.DBService;
using Anket.Repository;
using Anket.Repository.Interface;
using BasePersonDBService.DataContext;
using BasePersonDBService.Interfaces;
using BasePersonDBService.Services;
using DSUContextDBService.DataContext;
using DSUContextDBService.Interfaces;
using DSUContextDBService.Services;

namespace Anket.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        private readonly BASEPERSONMDFContext _bASEPERSONMDFContext;
        private readonly DSUContext _dSUContext;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IConfiguration Configuration;

        public UnitOfWork(ApplicationContext context, IWebHostEnvironment appEnvironment, IConfiguration configuration, BASEPERSONMDFContext bASEPERSONMDFContext,
            DSUContext dSUContext)
        {
            _context = context;
            _bASEPERSONMDFContext = bASEPERSONMDFContext;
            _dSUContext = dSUContext;
            _appEnvironment = appEnvironment;
            Configuration = configuration;
        }

        public IAnketRepository AnketRepository
        {
            get
            {
                IAnketRepository anketRepository = new AnketaRepository(_context);
                return anketRepository;
            }
        }

        public IAnswerRepository AnswerRepository
        {
            get
            {
                IAnswerRepository answerRepository = new AnswerRepository(_context);
                return answerRepository;
            }
        }

        public IQuestionRepository QuestionRepository
        {
            get
            {
                IQuestionRepository questionRepository = new QuestionRepository(_context);
                return questionRepository;
            }
        }

        public IResultRepository ResultRepository
        {
            get
            {
                IResultRepository resultRepository = new ResultRepository(_context);
                return resultRepository;
            }
        }

        public ITestingTeacherRepository TestingTeacherRepository
        {
            get
            {
                ITestingTeacherRepository testingTeacherRepository = new TestingTeacherRepository(_context);
                return testingTeacherRepository;
            }
        }

        public IDSUActiveData DSUActiveData
        {
            get
            {
                IDSUActiveData dSUActiveData = new DSUActiveData(_dSUContext);
                return dSUActiveData;
            }
        }

        public IBasePersonActiveData BasePersonActiveData
        {
            get
            {
                IBasePersonActiveData basePersonActiveData = new BasePersonActiveData(_bASEPERSONMDFContext);
                return basePersonActiveData;
            }
        }
    }
}
