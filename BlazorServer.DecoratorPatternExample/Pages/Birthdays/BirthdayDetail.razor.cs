using Microsoft.AspNetCore.Components;

namespace BlazorServer.DecoratorPatternExample.Pages.Birthdays
{
    public partial class BirthdayDetail
    {
        [Parameter]
        public int BirthdayId { get; set; }
    }
}
