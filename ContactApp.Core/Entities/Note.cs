using System;
using SQLite;
namespace ContactApp.Core.Entities
{
	public class Note
	{
		[PrimaryKey]
		public string ID { get; set; } = Guid.NewGuid().ToString();
		public string Title { get; set; }
		public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Note()
		{
		}
	}
}

