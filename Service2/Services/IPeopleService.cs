using Service2.ObjectValues;

namespace Service2.Services
{
    public interface IPeopleService 
    {

        IEnumerable<PeopleVO> FindAll();
    }
}