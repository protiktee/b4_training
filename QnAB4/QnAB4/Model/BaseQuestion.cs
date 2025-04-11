using System.ComponentModel.DataAnnotations;

namespace QnAB4.Model
{
    public class BaseQuestion
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string MakeDate { get; set; } 
        public string MakeUser { get; set; }
    }
}
