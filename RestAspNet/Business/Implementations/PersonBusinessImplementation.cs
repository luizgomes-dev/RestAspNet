using RestAspNet.Model; 
using RestAspNet.Repository.Generic;

namespace RestAspNet.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IRepository<Person> _repository;
        public PersonBusinessImplementation(IRepository<Person> repository)
        {
            _repository = repository;
        }
        public Person Create(Person person)
        {
            return _repository.Create(person); 
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }
                
        public Person FindByID(long id)
        {
            var result = _repository.FindByID(id);
            return result; 
        }

        public Person Update(Person person)
        { 
            return _repository.Update(person);      
        }

        private bool Exists(int id)
        {
            return _repository.Exists(id);
        }
    }
}
