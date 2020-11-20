using System;
using System.ComponentModel.DataAnnotations;

namespace Teams.Domain
{
    public class Entity
    {
        [Key]
        public Guid Id { get; private set; }
    }
}
