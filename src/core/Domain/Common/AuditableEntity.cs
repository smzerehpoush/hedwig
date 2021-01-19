using System;

namespace Domain.Common
{
    public class AuditableEntity
    {
        public string CreatedBy { get; set; }

        public DateTime CreationDate { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModificationDate { get; set; }
    }
}