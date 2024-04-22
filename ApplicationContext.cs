using RaidControllerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace RaidControllerApi
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }
        public DbSet<PlayerModel> Players { get; set; }
        public DbSet<RaidModel> Raid { get; set; }
    }
}
