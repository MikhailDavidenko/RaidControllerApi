using RaidControllerApi.Interfaces.Repositories;
using RaidControllerApi.Interfaces.Services;

namespace RaidControllerApi.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public void ChangeStatusForAll(bool? status)
        {
            var players = _playerRepository.GetAll();
            foreach (var player in players)
            {
                player.Status = status;
            }

            _playerRepository.UpdateAll(players);
        }
        public void ChangeRaidId(int id)
        {
            var players = _playerRepository.GetAllWhereStatusNotNull();
            foreach (var player in players)
            {
                player.RaidId = id;
            }

            _playerRepository.UpdateAll(players);
        }
    }
}
