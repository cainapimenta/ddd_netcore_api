using System;
using System.ComponentModel.DataAnnotations;

namespace API.Domain.Entities
{
    public class BaseEntity
    {
        private DateTime? _createAt;

        [Key]
        public Guid Id { get; set; }
        public DateTime? CreateAt
        {
            get { return _createAt; }
            set { _createAt = (value == null ? DateTime.UtcNow : value); }
        }
        public DateTime? UpdateAt { get; set; }

        public BaseEntity()
        {

        }
    }
}
