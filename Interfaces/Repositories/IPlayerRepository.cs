using RaidControllerApi.Models;

namespace RaidControllerApi.Interfaces.Repositories
{
    public interface IPlayerRepository
    {
        public List<PlayerModel> GetAll();
        public List<PlayerModel> GetAllWhereStatusNotNull();
        public void UpdateAll(List<PlayerModel> players);
    }
}
