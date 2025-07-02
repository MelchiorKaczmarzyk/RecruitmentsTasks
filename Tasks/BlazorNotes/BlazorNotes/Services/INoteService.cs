using BlazorNotes.Data.Models;

namespace BlazorNotes.Services
{
    public interface INoteService
    {
        void AddNote(Note note);
        List<Note> GetAll();
        void DeleteNote(int id);
        void UpdateNote(Note updatedNote);

    }
}
