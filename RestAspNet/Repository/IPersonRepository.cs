using RestAspNet.Model;

namespace RestAspNet.Repository
{
    public interface IPersonRepository
    {

        Person Create(Person person);

        Person FindById(int id);

        List<Person> FindAll();

        Person Update(Person person);

        void Delete(int id);

        bool Exists(int id);
    }
}
