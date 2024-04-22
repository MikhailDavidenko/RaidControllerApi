namespace RaidControllerApi.Interfaces.Services
{
    public interface IRaidService
    {
        public int StartRaid();
        public bool FinishRaid(int id);

    }
}
