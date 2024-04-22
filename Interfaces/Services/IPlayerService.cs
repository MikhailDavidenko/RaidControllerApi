namespace RaidControllerApi.Interfaces.Services
{
    public interface IPlayerService
    {
        public void ChangeStatusForAll(bool? status);
        public void ChangeRaidId(int id);
    }
}
