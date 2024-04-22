using RaidControllerApi.Interfaces.Repositories;
using RaidControllerApi.Models;

namespace RaidControllerApi.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private ApplicationContext _context;
        public PlayerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<PlayerModel> GetAll()
        {
            return _context.Players.ToList();
        }


        public List<PlayerModel> GetAllWhereStatusNotNull()
        {
            return _context.Players.Where(p => p.Status != null).ToList();
        }

        public void UpdateAll(List<PlayerModel> players)
        {
            _context.Players.UpdateRange(players);
            _context.SaveChanges();
        }
    }
}
