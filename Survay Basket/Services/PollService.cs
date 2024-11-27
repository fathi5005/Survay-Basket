using Survay_Basket.Entities;
using System.Xml.Linq;

namespace Survay_Basket.Services
{
    public class PollService : IPollService
    {
        public static List<Poll> PollList = new()
        {
            new Poll{Id=1,Title="poll 1",Description="poll at first "},
            new Poll{Id=2,Title="poll 2",Description="poll at second "}




        };


        public IEnumerable<Poll> GetAll()
        {
            return PollList;
        }

        public Poll? Get(int id)
        {
            var poll = PollList.SingleOrDefault(x => x.Id == id);

            return poll;
        }
        public Poll Add(Poll Request)
        {
            Request.Id = (PollList.Count) + 1;
            PollList.Add(Request);
            return Request;
        }


        public bool Update(int id, Poll request)
        {
            var currentPoll = Get(id);

            if (currentPoll is null)
                return false;

            currentPoll.Title = request.Title;
            currentPoll.Description = request.Description;
            return true;


        }

        public bool Delete(int id)
        {
            var currentPoll = Get(id);

            if (currentPoll is null)
                return false;

            PollList.Remove(currentPoll);
            return true;
        }




    }
}
