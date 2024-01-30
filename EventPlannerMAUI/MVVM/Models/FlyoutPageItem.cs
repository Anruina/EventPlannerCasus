namespace EventPlannerMAUI.MVVM.Models
{

    public class FlyoutPageItem
    {

        public string? Title { get; set; }
        public string? IconSource { get; set; }
        public required Type TargetType { get; set; }

    }

}
