using System;
using System.ComponentModel.DataAnnotations;

namespace ItServiceApp.Models.Entites
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        [StringLength(128)]
        public string CreatedUser { get; set; }
        public DateTime? UpdateTime { get; set; }
        [StringLength(128)]
        public string UpdatedUser { get; set; }

    }
}
