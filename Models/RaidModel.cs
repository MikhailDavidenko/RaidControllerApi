namespace RaidControllerApi.Models
{
    public class RaidModel
    {
        public RaidModel(DateTime start, DateTime finish, bool isActive)
        {
            Start = start;
            Finish = finish;
            IsActive = isActive;
            Duration = 45;
        }

        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public bool IsActive { get; set; }
        public int Duration { get; set; }

    }
}
