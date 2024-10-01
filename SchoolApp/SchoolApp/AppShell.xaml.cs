namespace SchoolApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(TeacherPage), typeof(TeacherPage));
        }
    }
}