using BlazorNotes.Data;
using BlazorNotes.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorNotes.Services
{
    public class NoteService : INoteService
    {
        private IDbContextFactory<MyDbContext> _dbContextFactory;

        public NoteService (
            Microsoft.EntityFrameworkCore.IDbContextFactory<MyDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public NoteService()
        {
        }

        public void AddNote(Note note)
        {
            using (var context = _dbContextFactory.CreateDbContext()) 
            {
                note.Id = 0;
                context.Notes.Add(note);
                context.SaveChanges();
            }
        }
        public List<Note> GetAll()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.Notes.ToList();
            }
        }
        public void DeleteNote(int id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Notes.FirstOrDefault(n => n.Id == id);
            }
        }
        public void UpdateNote(Note updatedNote)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var existingNote = context.Notes.FirstOrDefault(n => n.Id == updatedNote.Id);
                if (existingNote != null)
                {
                    existingNote.Title = updatedNote.Title;
                    existingNote.Text = updatedNote.Text;
                    context.SaveChanges();
                }
            }
        }

        public Note GetNoteById(int id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var note = context.Notes.FirstOrDefault(n => n.Id == id);
                if(note != null) 
                {
                    return note;
                }
                else return new Note();
            }
        }
    }
}
