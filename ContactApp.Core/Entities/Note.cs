using System;
namespace ContactApp.Core.Entities
{
	public class Note
	{
		public string ID { get; set; } = Guid.NewGuid().ToString();
		public string Title { get; set; }
		public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Note()
		{
		}
	}
}

