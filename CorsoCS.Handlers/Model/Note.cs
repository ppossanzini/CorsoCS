using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorsoCS.Handlers.Model
{
    [Table("Notes")]
    public class Note
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        [StringLength(500)]
        public string Title { get; set; }
        public string Body { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }

        public bool Flagged { get; set; }
    }
}