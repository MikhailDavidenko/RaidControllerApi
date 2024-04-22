using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RaidControllerApi.Models
{
    public class PlayerModel
    {
        public int Id { get; set; }
        public int RaidId { get; set; }
        public string Alias { get; set; }
        public bool? Status { get; set; }
        public int CardId { get; set; }
    }
}
