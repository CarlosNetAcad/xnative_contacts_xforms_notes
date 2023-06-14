using System;
using ContactApp.Core.Entities;
using Prism.Events;

namespace NotesForms.Events
{
	public class NoteEvent : PubSubEvent<NoteEventPayload>
	{
	}

	public class NoteEventPayload
	{
		public Note Note { get; set; }
		public NoteEventAction Action { get; set; }
	}

	public enum NoteEventAction
	{
		None	= 0,
		Save	= 1,
		Delete	= 2,
		Update	= 3
	}
}

