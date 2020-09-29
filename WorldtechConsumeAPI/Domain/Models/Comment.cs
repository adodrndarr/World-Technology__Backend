using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string User { get; set; } = "Anonymous";
        public string Message { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
