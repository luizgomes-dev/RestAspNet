using RestAspNet.Data.Converter.Implementation;
using RestAspNet.Data.VO;
using RestAspNet.Model; 
using RestAspNet.Repository.Generic;

namespace RestAspNet.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IRepository<Person> _repository;
        private readonly PersonConverter _converter;
        public PersonBusinessImplementation(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }
        public PersonVO Create(PersonVO person)
        {   
            var personEntity = _converter.Parse(person);
            return _converter.Parse(_repository.Create(personEntity)); 
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }
                
        public PersonVO FindByID(long id)
        {
            var result = _repository.FindByID(id);
            return _converter.Parse(result); 
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            return _converter.Parse(_repository.Update(personEntity));      
        }

        private bool Exists(int id)
        {
            return _repository.Exists(id);
        }
    }
}
