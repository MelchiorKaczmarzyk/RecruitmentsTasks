using System.ComponentModel.DataAnnotations;

namespace BlazorNotes.Data.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Text is required.")]
        public string Text { get; set; }
    }
}
