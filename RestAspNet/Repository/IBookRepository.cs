using RestAspNet.Model;

namespace RestAspNet.Repository
{
    public interface IBookRepository
    {
        Book Create(Book person);

        Book FindById(int id);

        List<Book> FindAll();

        Book Update(Book book);

        void Delete(int id);

        bool Exists(int id);
    }
}
