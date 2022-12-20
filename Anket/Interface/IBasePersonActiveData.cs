using Anket.Models;

namespace Anket.Interface
{
    public interface IBasePersonActiveData
    {
        public List<PersFilial> GetPersFilials();
        public PersFilial GetPersFilial(int id);
        public List<PersDivision> GetPersDivisions();
        public PersDivision GetPersDivision(int id);
        public List<PersDepartment> GetPersDepartments();
        public PersDepartment GetPersDepartment(int id);
        public List<Person> GetPersons();
        public Person GetPerson(int id);
    }
}
