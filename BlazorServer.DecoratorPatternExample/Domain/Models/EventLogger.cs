using System.ComponentModel.DataAnnotations;

namespace BlazorServer.DecoratorPatternExample.Domain.Models
{
    public class EventLogger : ModelBase
    {
        [Required]
        public string? Service { get; set; }

        [Required]
        public string? Action { get; set; }

        [Required]
        public string? RequestData { get; set; }

        [Required]
        public DateTime? ActionDateTime { get; set; }
    }
}
