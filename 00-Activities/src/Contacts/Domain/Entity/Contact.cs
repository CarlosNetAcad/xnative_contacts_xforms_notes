using System;
namespace _00_Activities.src.Contacts.Domain.Entity
{
	public class Contact
	{
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public string FullName { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; }
	}
}

