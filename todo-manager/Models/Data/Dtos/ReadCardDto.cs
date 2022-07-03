using System;

namespace todo_manager.Models.Data.Dtos
{
    public class ReadCardDto
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string UserStory { get; set; }
        public DateTime DeadLine { get; set; }
        public string Priority { get; set; }
        public DateTime DateRequest
        {
            get { return DateTime.Now; }
        }
    }
}
