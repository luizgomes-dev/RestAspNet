using RestAspNet.Model;
using RestAspNet.Model.Context;

namespace RestAspNet.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        private MySQLContext _context;
        public PersonRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            } catch (Exception)
            {
                throw;
            }

            return person;
        }

        public void Delete(int id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }   
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(int id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            return result; 
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return null;
            
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return person;
        }

        public bool Exists(int id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
         
    }
}
