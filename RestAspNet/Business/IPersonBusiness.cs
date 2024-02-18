using RestAspNet.Data.VO;
using RestAspNet.Model;

namespace RestAspNet.Business
{
    public interface IPersonBusiness
    {

        PersonVO Create(PersonVO person);

        PersonVO FindByID(int id);

        List<PersonVO> FindAll();

        PersonVO Update(PersonVO person);

        void Delete(int id);
    }
}
