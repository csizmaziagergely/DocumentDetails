using System.ComponentModel.DataAnnotations;

namespace DocumentDetails.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string HashedPassword { get; set; }
        public bool IsActive { get; set; }
    }
}
