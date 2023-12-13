using System.ComponentModel.DataAnnotations;

namespace BlazorServer.DecoratorPatternExample.Domain.Models
{
    public class CalendarBaseModel : ModelBase
    {
        [Required]
        public Boolean? IsActive { get; set; }

        [Required]
        public DateTime? Date { get; set; }
    }
}
