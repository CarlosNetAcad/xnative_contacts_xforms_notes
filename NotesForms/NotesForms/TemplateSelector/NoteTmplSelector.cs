using System;
using ContactApp.Core.Entities;
using Xamarin.Forms;

namespace NotesForms.TemplateSelector
{
    public class NoteTmplSelector : DataTemplateSelector
    {
        public DataTemplate TmplVideo   { get; set; }
        public DataTemplate TmplMusic   { get; set; }
        public DataTemplate TmplImage   { get; set; }
        public DataTemplate TmplDefault { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var note = item as Note;

            switch( note.NoteType)
            {
                case NoteType.Video:
                    return TmplVideo;
                case NoteType.Music:
                    return TmplMusic;
                case NoteType.Image:
                    return TmplImage;
                case NoteType.Default:
                default:
                    return TmplDefault;
            }
        }
    }
}

