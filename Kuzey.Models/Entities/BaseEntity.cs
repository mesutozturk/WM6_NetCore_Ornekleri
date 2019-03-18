using System;
using System.ComponentModel.DataAnnotations;

namespace Kuzey.Models.Entities
{
    public abstract class BaseEntity<T> : AuditEntity
    {
        [Key]
        public T Id { get; set; }

    }
    public abstract class AuditEntity
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [StringLength(450)]
        public string CreatedUserId { get; set; }

        public DateTime? UpdatedDate { get; set; }
        [StringLength(450)]
        public string UpdatedUserId { get; set; }
    }
}
