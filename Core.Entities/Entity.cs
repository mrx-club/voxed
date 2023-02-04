using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; init; } = Guid.NewGuid();
        public DateTimeOffset CreatedOn { get; init; } = DateTimeOffset.Now;
        public DateTimeOffset UpdatedOn { get; set; } = DateTimeOffset.Now;
    }
}
