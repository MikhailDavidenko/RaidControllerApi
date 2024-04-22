using Microsoft.EntityFrameworkCore;
using RaidControllerApi.Interfaces.Repositories;
using RaidControllerApi.Models;


namespace RaidControllerApi.Repositories
{
    public class RaidRepository : IRaidRepository
    {
        private ApplicationContext _context;
        public RaidRepository(ApplicationContext context)
        {
            _context = context;
        }

        public RaidModel Get(int id)
        {
            return _context.Raid.Where(r => r.Id == id).OrderBy(r => r.Id).FirstOrDefault();
        }

        public int Add(RaidModel raid)
        {
            _context.Raid.Add(raid);
            _context.SaveChanges();
            int id = _context.Raid.OrderBy(r => r.Id).LastOrDefault().Id;
            
            return id;
        }

        public void Update(RaidModel raid)
        {
            _context.Raid.Update(raid);
            _context.SaveChanges();
        }

        public void Finish(int id)
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationContext>()
                .UseNpgsql(@"")
                .Options;
            using (var context = new ApplicationContext(contextOptions))
            {
                var raid = context.Raid.Where(p => p.Id == id).OrderBy(p => p.Id).LastOrDefault();
                if (raid.IsActive)
                {
                    raid.IsActive = false;
                    context.Raid.Update(raid);
                    context.SaveChanges();
                }
            }
        }
    }
}
