using System;
using SQLite;
namespace ContactApp.Core.Entities
{
	public class Note
	{
        #region Flds
		public static int TotalNotes = 100;
		#endregion Flds

        #region Props
        [PrimaryKey]
		public string ID			{ get; set; } = Guid.NewGuid().ToString();
		public string Title			{ get; set; }
		public string Content		{ get; set; }
        public DateTime CreatedAt	{ get; set; } = DateTime.Now;
		public int iNoteType		{ get; set; }
		public double Longitude		{ get; set; }
		public double Latitude		{ get; set; }

		[Ignore]
		public NoteType NoteType
		{
			get => (NoteType)iNoteType;
		}
		#endregion Props

        #region __constructor
		public Note() {}
        #endregion __constructor
    }

    public enum NoteType
	{
		Default	= 0,
		Music	= 1,
		Video	= 2,
		Image	= 3,
	}
}

