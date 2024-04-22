using RaidControllerApi.Models;

namespace RaidControllerApi.Interfaces.Repositories
{
    public interface IRaidRepository
    {
        public RaidModel Get(int id);
        public int Add(RaidModel raid);
        public void Update(RaidModel Raid);
        public void Finish(int id);
    }
}
