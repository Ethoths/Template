using System;

namespace Models
{
    public sealed class DomainEntity
    {
        public int Id { get; set; }

        public Guid Gid { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
