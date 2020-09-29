using System;


namespace Presentation.ViewModels
{
    public class CommentVM
    {
        public string User { get; set; } = "Anonymous";
        public string Message { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}