using System;
using SQLite;

namespace _00_Activities.src.Contacts.Domain.Entity
{
	public class Profile
	{
        [PrimaryKey]
        public string ID { get; set; } = Guid.NewGuid().ToString();
        [Unique]
        public string Name { get; set; }
        public string Desc { get; set; }
        public DateTime CreatedAt { get; set; }
	}
}

