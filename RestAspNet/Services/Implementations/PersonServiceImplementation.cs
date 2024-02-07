using RestAspNet.Model;
using RestAspNet.Model.Context;

namespace RestAspNet.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private MySQLContext _context;
        public PersonServiceImplementation(MySQLContext context)
        {
            _context = context;
        }
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            } catch (Exception ex)
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
            if (!Exists(person.Id)) return new Person();
            
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

        private bool Exists(int id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}
