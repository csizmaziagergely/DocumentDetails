using DocumentDetails.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentDetails.Entities
{
    public class UserLog
    {
        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime HappenedAt { get; set; }
        public UserLogType Type { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public string IPAddress { get; set; }
        public string UsernameAttempt { get; set; }
    }
}
