using System;
using SQLite;

namespace ContactApp.Core.Entities
{
	public class Contact
	{
        [PrimaryKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Fullname { get; set; }
        [Unique]
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

