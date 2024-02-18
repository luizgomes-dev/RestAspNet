using RestAspNet.Data.VO;
using RestAspNet.Model;

namespace RestAspNet.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);
        BookVO FindByID(int id);
        List<BookVO> FindAll();
        BookVO Update(BookVO book);
        void Delete(long id);
    }

}
