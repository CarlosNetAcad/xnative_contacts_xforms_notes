using System;
using SQLite;

namespace ContactApp.Core.Entities
{
	public class User
	{
        [PrimaryKey]
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string PassWord { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public User()
		{
		}
	}
}