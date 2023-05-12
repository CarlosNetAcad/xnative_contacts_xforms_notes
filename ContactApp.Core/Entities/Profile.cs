using System;
using SQLite;

namespace ContactApp.Core.Entities
{
	public class Profile
	{
        [PrimaryKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public bool ProfileStatus { get; set; }
    }
}

