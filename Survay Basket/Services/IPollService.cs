using Survay_Basket.Entities;

namespace Survay_Basket.Services
{
    public interface IPollService
    {
        IEnumerable<Poll> GetAll();
        Poll? Get(int id);
        Poll Add(Poll Request);
        bool Update(int id, Poll request);
        bool Delete(int id);


    }
}
