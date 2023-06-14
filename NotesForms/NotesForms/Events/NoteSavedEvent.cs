using System;
using ContactApp.Core.Entities;
using Prism.Events;

namespace NotesForms.Events
{
	public class NoteSavedEvent:PubSubEvent<Note>
	{
	}
}