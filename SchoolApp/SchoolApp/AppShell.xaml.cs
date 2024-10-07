namespace SchoolApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(TeacherPage), typeof(TeacherPage));
            Routing.RegisterRoute(nameof(SupportPage), typeof(SupportPage));
            Routing.RegisterRoute(nameof(HandymanPage), typeof(HandymanPage));
            Routing.RegisterRoute(nameof(StudentPage), typeof(StudentPage));
        }
    }
}