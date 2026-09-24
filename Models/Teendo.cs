using System.ComponentModel.DataAnnotations;

namespace ToDoListWebApp.Models
{
    public class Teendo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A cím megadása kötelező!")]
        [StringLength(150, ErrorMessage = "A cím maximum 150 karakter lehet!")]
        public string Cim { get; set; }
        public DateTime Hatarido { get; set; } = DateTime.Today;
        public bool Kesz { get; set; } = false;
    }
}
