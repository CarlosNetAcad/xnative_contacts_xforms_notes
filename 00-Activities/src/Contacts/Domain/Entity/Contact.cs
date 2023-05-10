using System;
using SQLite;

namespace _00_Activities.src.Contacts.Domain.Entity
{
	public class Contact
	{
        [PrimaryKey]
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public string FullName { get; set; }
        [Unique]
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; }
	}
}

