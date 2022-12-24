using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasePersonDBService.Interfaces
{
    public interface IBasePersonActiveData
    {
        public IQueryable<PersFilial> GetPersFilials();
        public PersFilial GetPersFilialById(int id);
        public IQueryable<PersDivision> GetPersDivisions();
        public PersDivision GetPersDivisionById(int id);
        public IQueryable<PersDepartment> GetPersDepartments();
        public PersDepartment GetPersDepartmentById(int id);
        public IQueryable<Person> GetPersons();
        public Person GetPersonById(int id);
    }
}
