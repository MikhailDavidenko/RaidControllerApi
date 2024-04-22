using Microsoft.EntityFrameworkCore;
using RaidControllerApi.Interfaces.Repositories;
using RaidControllerApi.Interfaces.Services;
using RaidControllerApi.Models;
using System.Text;
using System.Threading;

namespace RaidControllerApi.Services
{
    public class RaidService : IRaidService
    {
        private readonly IRaidRepository _raidRepository;
        public RaidService(IRaidRepository raidRepository)
        {
            _raidRepository = raidRepository;
        }

        public int StartRaid()
        {
            var raid = new RaidModel(DateTime.Now, DateTime.Now.AddMinutes(45), true);

            int id = _raidRepository.Add(raid);
            StartTimer(id);
            return id;

        }

        public bool FinishRaid(int id)
        {
            var  raid = _raidRepository.Get(id);
            if(raid == null)
                return false;
            raid.IsActive = false;
            _raidRepository.Update(raid);
            return true;

        }

        public void StartTimer(int id)
        {
            int time = 2400000;//40 минут в мс
            Timer ts = new Timer(FinishTimer, id, time, Timeout.Infinite);
        }

        public void FinishTimer(object? obj)
        {
            int id = (int)obj;

            _raidRepository.Finish(id);
        }
    }
}
