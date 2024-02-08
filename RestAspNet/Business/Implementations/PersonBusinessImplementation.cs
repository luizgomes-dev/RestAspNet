using RestAspNet.Model;
using RestAspNet.Model.Context;
using RestAspNet.Repository;
using System;

namespace RestAspNet.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IPersonRepository _repository;
        public PersonBusinessImplementation(IPersonRepository repository)
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

        public Person FindById(int id)
        {
            var result = _repository.FindById(id);
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
