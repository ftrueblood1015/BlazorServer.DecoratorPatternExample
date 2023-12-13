using Microsoft.AspNetCore.Components;

namespace BlazorServer.DecoratorPatternExample.Pages.Anniversaries
{
    public partial class AnniversaryDetail
    {
        [Parameter]
        public int AnniversaryId { get; set; }
    }
}
