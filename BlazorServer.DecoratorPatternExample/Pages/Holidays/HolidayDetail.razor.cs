using Microsoft.AspNetCore.Components;

namespace BlazorServer.DecoratorPatternExample.Pages.Holidays
{
    public partial class HolidayDetail
    {
        [Parameter]
        public int HolidayId { get; set; }
    }
}
